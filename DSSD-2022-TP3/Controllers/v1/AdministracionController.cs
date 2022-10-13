using DSSD_2022_TP3.Model;
using DSSD_2022_TP3.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Swashbuckle.AspNetCore.Annotations;

namespace DSSD_2022_TP3.Controllers.v1
{
    [Route("api/administracion")]
    [ApiController]
    public class AdministracionController : ControllerBase
    {
        private readonly AcademicaContext _context;

        public AdministracionController(AcademicaContext context)
        {
            _context = context;
        }
        // GET: api/v1/administracion/carreras
        [SwaggerOperation(Description = "Obiene el listado completo de carreras", Summary = "Obtener listado de carreras")]
        [SwaggerResponse(200, "Listado completo")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("carreras")]
        public async Task<ActionResult<IEnumerable<Carrera>>> GetCarreras()
        {
            var carreras = await _context.Carreras.ToListAsync();
            if (carreras.Count == 0) return NoContent();
            return Ok(carreras);
        }
        // GET: api/v1/administracion/carreras/1
        [SwaggerOperation(Description = "Obiene el listado completo de materia filtrado por idCarrera", Summary = "Obtener listado de materias por carrera")]
        [SwaggerResponse(200, "Listado completo")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("materias/{idCarrera}")]
        public async Task<ActionResult<IEnumerable<Materia>>> GetMateriasByCarrera(int idCarrera)
        {
            var materias = await _context.Materias.Where(m => m.IdCarrera == idCarrera).ToListAsync();
            if (materias.Count == 0) return NoContent();
            return Ok(materias);
        }
        // GET: api/v1/administracion/carreras
        [SwaggerOperation(Description = "Obiene el listado completo de turnos", Summary = "Obtener listado de turnos")]
        [SwaggerResponse(200, "Listado completo")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("turnos")]
        public async Task<ActionResult<IEnumerable<Turno>>> GetTurnos()
        {
            var turnos = await _context.Turnos.ToListAsync();
            if (turnos.Count == 0) return NoContent();
            return Ok(turnos);
        }

        // GET: api/v1/administracion/carreras
        [SwaggerOperation(Description = "Obiene el listado completo de dias de la semana", Summary = "Obtener listado de dias")]
        [SwaggerResponse(200, "Listado completo")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("dias")]
        public async Task<ActionResult<IEnumerable<Dia>>> GetDias()
        {
            var dias = await _context.Dias.ToListAsync();
            if (dias.Count == 0) return NoContent();
            return Ok(dias);
        }

        // GET: api/v1/administracion/cursada/{}
        [SwaggerOperation(Description = "Obiene el listado completo de cursadas por cuatrimestre", Summary = "Obtener listado de cursadas")]
        [SwaggerResponse(200, "Listado completo")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("cursada/{cuatrimestre}")]
        public async Task<ActionResult<IEnumerable<ComisionPost>>> GetCursadasByCuatrimestre(int cuatrimestre)
        {
            var comisiones = await _context.Comisiones.Include(c => c.Usuario)
                .Include(c => c.Turno)
                .Include(c => c.Materia)
                .Include(c => c.Usuario)
                .Include(c => c.Dia)
                .Where(c => c.NroComision == cuatrimestre)
                .ToListAsync();
            if (comisiones.Count == 0) return NoContent();
            List<ComisionResponse> response = new List<ComisionResponse>();
            foreach (var comision in comisiones)
            {
                ComisionResponse x = new ComisionResponse()
                {
                    Materia = comision.Materia.Nombre,
                    Dia = comision.Dia.Nombre,
                    Horario = comision.RangoHorario,
                    Turno = comision.Turno.Nombre,
                    Docente = $"{comision.Usuario.Nombre} {comision.Usuario.Apellido}",
                    Anio = comision.Anio,
                    Cuatrimestre = comision.NroComision
                };
                response.Add(x);
            }
            return Ok(response);
        }

        // POST: api/v1/administracion/cursada
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPost("cursada")]
        public async Task<ActionResult<ComisionPost>> PostCursada(ComisionPost comisionPost)
        {
            Inscripcion inscripcion = new Inscripcion() { IdInstancia = 1, Desde = comisionPost.HoraInicio, Hasta = comisionPost.HoraFin, Fecha = "", FechaCierre = "", Anio = comisionPost.Anio, Descripcion = "" };
            var saveInscripcion = _context.Inscripciones.Add(inscripcion);
            Comision comision = new Comision() { Inscripcion = saveInscripcion.Entity, IdTurno = comisionPost.IdTurno, IdMateria = comisionPost.IdMateria, IdUsuario = comisionPost.IdDocente, IdDia = comisionPost.Dia, NroComision = comisionPost.Cuatrimestre, Anio = comisionPost.Anio, RangoHorario = $"{comisionPost.HoraInicio}-{comisionPost.HoraFin}" };
            _context.Comisiones.Add(comision);
            await _context.SaveChangesAsync();
            return comisionPost;
        }
    }
}

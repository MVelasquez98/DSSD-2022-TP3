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
        [SwaggerResponse(204, "Listado Vacio")]
        [SwaggerResponse(500, "Error Interno")]
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
        [SwaggerResponse(204, "Listado Vacio")]
        [SwaggerResponse(500, "Error Interno")]
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
        [SwaggerResponse(204, "Listado Vacio")]
        [SwaggerResponse(500, "Error Interno")]
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
        [SwaggerResponse(204, "Listado Vacio")]
        [SwaggerResponse(500, "Error Interno")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("dias")]
        public async Task<ActionResult<IEnumerable<Dia>>> GetDias()
        {
            var dias = await _context.Dias.ToListAsync();
            if (dias.Count == 0) return NoContent();
            return Ok(dias);
        }

        // POST: api/v1/administracion/inscripcion
        [SwaggerOperation(Description = "Se almacena una inscripcion que puede ser del tipo Final o cursada", Summary = "Guardar inscripcion")]
        [SwaggerResponse(200, "Inscripcion Creada")]
        [SwaggerResponse(500, "Error Interno")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPost("inscripcion")]
        public async Task<ActionResult<InscripcionDTO>> PostInscripcion(InscripcionDTO inscripcionDto)
        {
            int cantInscripciones = _context.Inscripciones.ToList().Count;
            Inscripcion inscripcion = new Inscripcion()
            {
                IdInstancia = inscripcionDto.Instancia,
                Descripcion = inscripcionDto.Descripcion,
                Desde = inscripcionDto.Desde,
                Hasta = inscripcionDto.Hasta,
                FechaInicio = inscripcionDto.FechaInicio,
                FechaFin = inscripcionDto.FechaFin,
                Anio = DateTime.Parse(inscripcionDto.FechaInicio).Year.ToString()
            };
            _context.Inscripciones.Add(inscripcion);
            await _context.SaveChangesAsync();
            return inscripcionDto;
        }

        // POST: api/v1/administracion/cursada
        [SwaggerOperation(Description = "Se almacena una comision del tipo cursada", Summary = "Guardar cursada")]
        [SwaggerResponse(200, "Cursada guardada")]
        [SwaggerResponse(500, "Error Interno")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPost("cursada")]
        public async Task<ActionResult<ComisionDTO>> PostCursada(ComisionDTO comisionDto)
        {
            int cantInscripciones = _context.Inscripciones.ToList().Count;
            Comision comision = new Comision()
            {
                IdInscripcion = comisionDto.IdInscripcion,
                IdTurno = comisionDto.IdTurno,
                IdMateria = comisionDto.IdMateria,
                IdUsuario = comisionDto.IdDocente,
                IdDia = comisionDto.Dia,
                NroComision = int.Parse($"{comisionDto.IdMateria}{cantInscripciones}"),
                Anio = comisionDto.Anio,
                RangoHorario = $"{comisionDto.HoraInicio}-{comisionDto.HoraFin}hs",
                Fecha = ""
            };
            _context.Comisiones.Add(comision);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}{ex.InnerException}");
            }
            return Ok(comisionDto);
        }
        // POST: api/v1/administracion/examen
        [SwaggerOperation(Description = "Se almacena una comision del tipo examen final", Summary = "Guardar examen final")]
        [SwaggerResponse(200, "Examen guardado")]
        [SwaggerResponse(500, "Error Interno")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPost("examen")]
        public async Task<ActionResult<ExamenDTO>> PostExamen(ExamenDTO examenDTO)
        {
            int cantInscripciones = _context.Inscripciones.ToList().Count;
            Comision comision = new Comision()
            {
                IdInscripcion = examenDTO.IdInscripcion,
                IdMateria = examenDTO.IdMateria,
                IdTurno = 1,
                IdDia = 1,
                IdUsuario = examenDTO.IdDocente,
                NroComision = int.Parse($"{examenDTO.IdMateria}{cantInscripciones}"),
                Anio = examenDTO.Anio,
                RangoHorario = $"{examenDTO.HoraInicio}hs",
                Fecha = examenDTO.Fecha
            };
            _context.Comisiones.Add(comision);
            await _context.SaveChangesAsync();
            return Ok(examenDTO);
        }
        //GET: api/administracion/inscripcion$idInstancia=<idInstancia>&fecha=<fechaActual>
        [SwaggerOperation(Description = "Obiene el listado completo de inscripciones de una instancia y fecha determinada, si la fecha es nula se recibe el listado completo de inscripciones", Summary = "Obtener listado de inscripciones por fecha e instancia")]
        [SwaggerResponse(200, "Listado completo")]
        [SwaggerResponse(204, "No existen resultados bajo esos criterios de busqueda")]
        [SwaggerResponse(500, "Error Interno")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("inscripcion")]
        public async Task<ActionResult> GetInscripciones(int idInstancia, string? fechaActual)
        {

            var inscripcionesSegunInstancia = _context.Inscripciones.Where(i => i.IdInstancia == idInstancia).ToList();
            if (fechaActual == null) return Ok(inscripcionesSegunInstancia);
            var inscripciones = inscripcionesSegunInstancia.Where(i => DateTime.Parse(fechaActual) >= DateTime.Parse(i.Desde)
            && DateTime.Parse(fechaActual) <= DateTime.Parse(i.Hasta)).ToList();

            if (inscripciones.Count == 0) return NoContent();
            List<InscripcionDTO> result = new List<InscripcionDTO>();
            foreach (var inscripcion in inscripciones)
            {
                InscripcionDTO inscripcionDTO = new InscripcionDTO()
                {
                    IdInscripcion = inscripcion.IdInscripcion,
                    Descripcion = inscripcion.Descripcion,
                    Desde = inscripcion.Desde,
                    FechaFin = inscripcion.FechaFin,
                    FechaInicio = inscripcion.FechaInicio,
                    Hasta = inscripcion.Hasta,
                    Instancia = inscripcion.IdInstancia
                };
                result.Add(inscripcionDTO);
            }
            return Ok(result);
        }
    }
}

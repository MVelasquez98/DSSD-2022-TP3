using DSSD_2022_TP3.Model;
using DSSD_2022_TP3.Repository;
using DSSD_2022_TP3.Repository.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSSD_2022_TP3.Controllers.v1
{
    [Route("api/v1/docente")]
    [ApiController]
    public class DocenteController : ControllerBase
    {
        private readonly AcademicaContext _context;
        public DocenteController(AcademicaContext context)
        {
            _context = context;
        }
        // GET: api/v1/docente/comision
        [SwaggerOperation(Description = "Obiene el listado completo de las comisiones asociado a un docente", Summary = "Obtener listado de comisiones de un docente")]
        [SwaggerResponse(200, "Listado completo")]
        [SwaggerResponse(204, "Listado vacio")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("comision")]
        public async Task<ActionResult<IEnumerable<ComisionDocenteDTO>>> GetComisiones(int idDocente)
        {
            var comisiones = await _context.Comisiones.Include(c => c.Inscripcion)
                            .Include(c => c.Materia)
                            .Where(c => c.IdUsuario == idDocente).Select(x => new ComisionDocenteDTO
                            {
                                IdComision = x.IdComision,
                                NombreMateria = x.Materia.Nombre,
                                DescripcionInscripcion = x.Inscripcion.Descripcion,
                                TipoInstancia = x.Inscripcion.IdInstancia,
                                FechaInicio = x.Inscripcion.FechaInicio,
                                FechaFin = x.Inscripcion.FechaFin

                            }).ToListAsync();
            if (comisiones.Count == 0) return NoContent();
            return Ok(comisiones);
        }
        // GET: api/v1/docente/tipoMateria
        [SwaggerOperation(Description = "Obiene el listado completo de los tipos de nota", Summary = "Obtener listado de tipos de nota")]
        [SwaggerResponse(200, "Listado completo")]
        [SwaggerResponse(204, "Listado vacio")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("tipoNota")]
        public async Task<ActionResult<IEnumerable<TipoNota>>> GetTiposDeNota()
        {
            var tiposDeNota = await _context.TipoNotas.ToListAsync();
            if (tiposDeNota.Count == 0) return NoContent();
            return Ok(tiposDeNota);
        }
        // GET: api/v1/docente/materias?idDocente=1
        [SwaggerOperation(Description = "Obiene el listado completo de materias asignadas a un docente", Summary = "Obtener listado de materias asignadas")]
        [SwaggerResponse(200, "Listado completo")]
        [SwaggerResponse(204, "Listado vacio")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("materias")]
        public async Task<ActionResult<IEnumerable<MateriaDTO>>> GetMaterias(int idDocente)
        {
            var materias = await _context.Comisiones
                .Include(c => c.Usuario)
                .Include(c => c.Materia).ThenInclude(m => m.Carrera)
                .Include(c => c.Turno)
                .Include(c => c.Inscripcion)
                .Where(c => c.IdUsuario == idDocente
                && c.Usuario.IdTipoUsuario == ((int)TiposUsuario.Docente)
                && c.Inscripcion.IdInstancia == ((int)TipoInstancia.Cursada))
                .Select(c => new { c.Materia.IdMateria, c.Materia.Nombre, carrera = c.Materia.Carrera.Nombre, turno = c.Turno.Nombre, c.RangoHorario, c.NroComision, c.Materia.AnioCarrera })
                .ToListAsync();
            if (materias.Count == 0) return NoContent();
            return Ok(materias);
        }
        // GET: api/v1/docente/alumnos/cursada?idDocente=1
        [SwaggerOperation(Description = "Obiene el listado completo de alumnos de cada materia asignada a un docente", Summary = "Obtener listado de alumnos")]
        [SwaggerResponse(200, "Listado completo")]
        [SwaggerResponse(204, "Listado vacio")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("alumnos/cursada")]
        public async Task<ActionResult<DetalleInscripcionDTO>> GetAlumnos(int idDocente, int idMateria)
        {
            var alumno = await _context.DetalleInscripciones
                .Include(d => d.Usuario)
                .Include(d => d.Inscripcion)
                .Include(d => d.Comision).ThenInclude(c => c.Materia)
                .Include(d => d.Comision).ThenInclude(c => c.Usuario)
                .Where(d => d.Comision.IdUsuario == idDocente
                && d.Inscripcion.IdInstancia == ((int)TipoInstancia.Cursada)
                && d.Comision.Materia.IdMateria == idMateria)
                .GroupBy(d => d.Comision.Materia.IdMateria)
                .Select(x => new DetalleInscripcionDTO()
                {
                    IdMateria = x.Select(a => a.Comision).FirstOrDefault().IdMateria,
                    NombreMateria = x.Select(a => a.Comision.Materia).FirstOrDefault().Nombre,
                    Alumnos = x.Select(x => new AlumnoDto()
                    {
                        Nombre = x.Usuario.Nombre,
                        Apellido = x.Usuario.Apellido,
                        PrimerParcial = _context.NotasComisiones.Where(n => n.IdUsuario == x.IdUsuario && n.IdTipoNota == 1).FirstOrDefault().Nota,
                        SegundoParcial = _context.NotasComisiones.Where(n => n.IdUsuario == x.IdUsuario && n.IdTipoNota == 2).FirstOrDefault().Nota,
                        NotaCursada = _context.NotasComisiones.Where(n => n.IdUsuario == x.IdUsuario && n.IdTipoNota == 10).FirstOrDefault().Nota,
                        NotaFinal = _context.NotasComisiones.Where(n => n.IdUsuario == x.IdUsuario && n.IdTipoNota == 11).FirstOrDefault().Nota,
                        NotaDefinitiva = _context.NotasComisiones.Where(n => n.IdUsuario == x.IdUsuario && n.IdTipoNota == 12).FirstOrDefault().Nota
                    }).ToList()
                })
                .FirstOrDefaultAsync();
            if (alumno == null) return NotFound();
            return Ok(alumno);
        }
        // POST: api/v1/docente/notaComision
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPost("notaComision")]
        public async Task<ActionResult> PostInscripcion(List<NotaComisionDTO> notas)
        {
            foreach (var notaComisionDto in notas)
            {
                NotaComision notaComision = new NotaComision()
                {
                    IdUsuario = notaComisionDto.IdEstudiante,
                    IdTipoNota = notaComisionDto.IdTipoNota,
                    Nota = notaComisionDto.Nota.ToString(),
                    Fecha = notaComisionDto.Fecha,
                    IdComision = notaComisionDto.IdComision,
                };
                _context.NotasComisiones.Add(notaComision);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }
    }
}

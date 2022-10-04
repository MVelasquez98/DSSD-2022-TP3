using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DSSD_2022_TP3.Model;
using Microsoft.AspNetCore.Cors;
using Swashbuckle.AspNetCore.Annotations;

namespace DSSD_2022_TP3.Controllers.v1
{
    [Route("api/v1/estudiantes")]
    [EnableCors]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly AcademicaContext _context;

        public EstudiantesController(AcademicaContext context)
        {
            _context = context;
        }

        // GET: api/v1/Estudiantes
        [SwaggerOperation(Description = "Obiene el listado completo de estudiantes", Summary = "Obtener listado de estudiantes")]
        [SwaggerResponse(200, "Listado completo")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiante>>> GetEstudiantes()
        {
            return await _context.Estudiantes.ToListAsync();
        }

        // GET: api/v1/Estudiantes/5
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetEstudiante(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);

            if (estudiante == null)
            {
                return NotFound();
            }

            return estudiante;
        }

        // PUT: api/v1/Estudiantes/5
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudiante(int id, Estudiante estudiante)
        {
            if (id != estudiante.IdEstudiante)
            {
                return BadRequest();
            }

            _context.Entry(estudiante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/v1/Estudiantes
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPost]
        public async Task<ActionResult<Estudiante>> PostEstudiante(Estudiante estudiante)
        {
            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstudiante", new { id = estudiante.IdEstudiante }, estudiante);
        }

        // DELETE: api/v1/Estudiantes/5
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstudianteExists(int id)
        {
            return _context.Estudiantes.Any(e => e.IdEstudiante == id);
        }
    }
}

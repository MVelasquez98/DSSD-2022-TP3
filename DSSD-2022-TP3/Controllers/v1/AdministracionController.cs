using DSSD_2022_TP3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return await _context.Carreras.ToListAsync();
        }
        // GET: api/v1/administracion/carreras/1
        [SwaggerOperation(Description = "Obiene el listado completo de materia filtrado por idCarrera", Summary = "Obtener listado de materias por carrera")]
        [SwaggerResponse(200, "Listado completo")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("materias/{idCarrera}")]
        public async Task<ActionResult<IEnumerable<Materia>>> GetMateriasByCarrera(int idCarrera)
        {
            return await _context.Materias.Where(m => m.IdCarrera == idCarrera).ToListAsync();
        }
        // GET: api/v1/administracion/carreras
        [SwaggerOperation(Description = "Obiene el listado completo de turnos", Summary = "Obtener listado de turnos")]
        [SwaggerResponse(200, "Listado completo")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("turnos")]
        public async Task<ActionResult<IEnumerable<Turno>>> GetTurnos()
        {
            return await _context.Turnos.ToListAsync();
        }
    }
}

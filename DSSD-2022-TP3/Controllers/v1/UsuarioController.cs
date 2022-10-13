using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DSSD_2022_TP3.Model;
using Microsoft.AspNetCore.Cors;
using Swashbuckle.AspNetCore.Annotations;
using DSSD_2022_TP3.Repository;

namespace DSSD_2022_TP3.Controllers.v1
{
    [Route("api/v1/usuario")]
    [EnableCors]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AcademicaContext _context;

        public UsuarioController(AcademicaContext context)
        {
            _context = context;
        }

        // POST: api/v1/usuario/login
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> Login(string username, string password)
        {
            Usuario? usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == username && u.Clave == password);
            if (usuario == null) return StatusCode(204, $"usrname:{username} y password:{password} no esta registrado");
            return usuario;
        }

        // GET: api/v1/estudiantes
        [SwaggerOperation(Description = "Obiene el listado completo de estudiantes", Summary = "Obtener listado de estudiantes")]
        [SwaggerResponse(200, "Listado completo")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("estudiantes")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetEstudiantes()
        {
            return await _context.Usuarios.Where(u => u.IdTipoUsuario == ((int)TiposUsuario.Estudiante)).ToListAsync();
        }

        // GET: api/v1/docentes
        [SwaggerOperation(Description = "Obiene el listado completo de docentes", Summary = "Obtener listado de docentes")]
        [SwaggerResponse(200, "Listado completo")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("docentes")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetDocentes()
        {
            return await _context.Usuarios.Where(u => u.IdTipoUsuario == ((int)TiposUsuario.Docente)).ToListAsync();
        }

        // GET: api/v1/docentes/1
        [SwaggerOperation(Description = "Obiene el listado de docentes segun el id de carrera", Summary = "Obtener listado de docentes segun carrera")]
        [SwaggerResponse(200, "Listado completo")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("docentes/{idCarrera}")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetDocentesByCarrera(int idCarrera)
        {
            return await _context.Usuarios.Where(u => u.IdTipoUsuario == ((int)TiposUsuario.Docente) && u.IdCarrera == idCarrera).ToListAsync();
        }

        // GET: api/v1/usuario/5
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var estudiante = await _context.Usuarios.FindAsync(id);

            if (estudiante == null)
            {
                return NotFound();
            }

            return estudiante;
        }

        // PUT: api/v1/usuarios/5
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest();
            }

            var userUpdate = _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUsuario", new { id = usuario.IdUsuario }, usuario);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/v1/usuario
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(UsuarioPost usuario)
        {
            Usuario userSave = new Usuario(usuario.Nombre, usuario.Apellido, usuario.Dni, usuario.Correo, usuario.Celular, usuario.IdCarrera, usuario.IdTipoUsuario);
            var userAdd = _context.Usuarios.Add(userSave);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUsuario", new { id = userAdd.Entity.IdUsuario }, userSave);
        }

        // DELETE: api/v1/usuarios/5
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var estudiante = await _context.Usuarios.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(estudiante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }
    }
}

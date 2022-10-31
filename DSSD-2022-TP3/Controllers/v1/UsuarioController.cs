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
        [SwaggerOperation(Description = "Obiene un usuario determinado a partir de su nombre de usuario y contraseña", Summary = "Obtiene los datos del usuario")]
        [SwaggerResponse(200, "Usuario encontrado")]
        [SwaggerResponse(404, "Nombre de usuario o contraseña no coinciden con ningun usuario registrado")]
        [SwaggerResponse(500, "Error Interno")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> Login(string username, string password)
        {
            Usuario? usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == username && u.Clave == password);
            if (usuario == null) return StatusCode(404, $"usrname:{username} y password:{password} no esta registrado");
            return Ok(usuario);
        }

        // GET: api/v1/estudiantes
        [SwaggerOperation(Description = "Obiene el listado completo de estudiantes", Summary = "Obtener listado de estudiantes")]
        [SwaggerResponse(200, "Listado completo")]
        [SwaggerResponse(204, "Listado vacio")]
        [SwaggerResponse(500, "Error Interno")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("estudiantes")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetEstudiantes()
        {
            var estudiantes = await _context.Usuarios.Where(u => u.IdTipoUsuario == ((int)TiposUsuario.Estudiante)).ToListAsync();
            if (estudiantes.Count == 0) return NoContent();
            return Ok(estudiantes);
        }

        // GET: api/v1/docentes
        [SwaggerOperation(Description = "Obiene el listado completo de docentes", Summary = "Obtener listado de docentes")]
        [SwaggerResponse(200, "Listado completo")]
        [SwaggerResponse(204, "Listado vacio")]
        [SwaggerResponse(500, "Error Interno")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("docentes")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetDocentes()
        {
            var docentes = await _context.Usuarios.Where(u => u.IdTipoUsuario == ((int)TiposUsuario.Docente)).ToListAsync();
            if (docentes.Count == 0) return NoContent();
            return Ok(docentes);
        }

        // GET: api/v1/docentes/1
        [SwaggerOperation(Description = "Obiene el listado de docentes segun el id de carrera", Summary = "Obtener listado de docentes segun carrera")]
        [SwaggerResponse(200, "Listado completo")]
        [SwaggerResponse(204, "No hay ningun docente asociado a esa carrera")]
        [SwaggerResponse(500, "Error Interno")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("docentes/{idCarrera}")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetDocentesByCarrera(int idCarrera)
        {
            var docentes = await _context.Usuarios.Where(u => u.IdTipoUsuario == ((int)TiposUsuario.Docente) && u.IdCarrera == idCarrera).ToListAsync();
            if (docentes.Count == 0) return NoContent();
            return Ok(docentes);
        }

        // GET: api/v1/usuario/5
        [SwaggerOperation(Description = "Obiene un usuario a partir de su id", Summary = "Obtener usuario")]
        [SwaggerResponse(200, "Usuario encontrado")]
        [SwaggerResponse(404, "No hay ningun usuario asociado a ese id")]
        [SwaggerResponse(500, "Error Interno")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var estudiante = await _context.Usuarios.FindAsync(id);

            if (estudiante == null)
            {
                return NotFound();
            }

            return Ok(estudiante);
        }

        // PUT: api/v1/usuarios/5
        [SwaggerOperation(Description = "Actualizar un usuario a partir de su id", Summary = "Actualizar usuario")]
        [SwaggerResponse(400, "El id del usuario no corresponde a ninguno registrado")]
        [SwaggerResponse(200, "Usuario modificado")]
        [SwaggerResponse(404, "No hay ningun usuario asociado a ese id")]
        [SwaggerResponse(500, "Error Interno")]
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
                return Ok(CreatedAtAction("GetUsuario", new { id = usuario.IdUsuario }, usuario));
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
        [SwaggerOperation(Description = "Registar un usuario", Summary = "Guardar usuario")]
        [SwaggerResponse(200, "Usuario guardado")]
        [SwaggerResponse(500, "Error Interno")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(UsuarioDTO usuario)
        {
            Usuario userSave = new Usuario(usuario.Nombre, usuario.Apellido, usuario.Dni, usuario.Correo, usuario.Celular, usuario.IdCarrera, usuario.IdTipoUsuario);
            var userAdd = _context.Usuarios.Add(userSave);
            await _context.SaveChangesAsync();
            return Ok(CreatedAtAction("GetUsuario", new { id = userAdd.Entity.IdUsuario }, userSave));
        }

        // DELETE: api/v1/usuarios/5
        [SwaggerOperation(Description = "Eliminar un usuario a partir de su id", Summary = "Eliminar usuario")]
        [SwaggerResponse(200, "Usuario eliminado")]
        [SwaggerResponse(404, "No hay ningun usuario asociado a ese id")]
        [SwaggerResponse(500, "Error Interno")]
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

            return Ok();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }
    }
}

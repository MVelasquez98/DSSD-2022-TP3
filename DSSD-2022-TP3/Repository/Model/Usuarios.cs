using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DSSD_2022_TP3.Model
{
    [Table("usuarios")]
    public class Usuario
    {
        public Usuario(string nombre, string apellido, string dni, string? correo, string celular, int idCarrera, int idTipoUsuario)
        {
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Correo = correo;
            Celular = celular;
            IdCarrera = idCarrera;
            IdTipoUsuario = idTipoUsuario;
            ForzarClave = true;
            Username = $"{nombre.Substring(0, 3).ToLower()}{apellido.ToLower()}{dni.Substring(0, 2)}";
            Clave = "Pass123";
        }

        /// <summary>
        /// ID que refiere a un usuario
        /// </summary>
        ///
        [Key]
        [Column("idUsuario")]
        public int IdUsuario { get; set; }
        /// <summary>
        /// nombre que identifica al usuario
        /// </summary>
        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }
        /// <summary>
        /// apellido que identifica al usuario
        /// </summary>
        [Required]
        [Column("apellido")]
        public string Apellido { get; set; }
        /// <summary>
        /// dni que identifica al usuario
        /// </summary>
        [Required]
        [Column("dni")]
        public string Dni { get; set; }
        /// <summary>
        /// usuario que identifica al usuario (basado en el nombre y apellido de la persona)
        /// </summary>
        [Column("usuario")]
        public string? Username { get; set; }
        /// <summary>
        /// clave que identifica al usuario (contraseña temporal de un solo uso que debe cambiarse al ingresar al sistema por primera vez) 
        /// </summary>
        [Column("clave")]
        public string? Clave { get; set; }
        /// <summary>
        /// correo como dato de contacto del usuario
        /// </summary>
        [Required]
        [Column("correo")]
        public string? Correo { get; set; }
        /// <summary>
        /// celular como dato de contacto del usuario
        /// </summary>
        [Required]
        [Column("celular")]
        public string Celular { get; set; }
        /// <summary>
        /// Id que identifica a la carrera del usuario
        /// </summary>
        [Required]
        [Column("idCarrera")]
        public int IdCarrera { get; set; }
        /// <summary>
        /// Id que identifica al Tipo de usuario
        /// </summary>
        [Required]
        [Column("idTipoUsuario")]
        public int IdTipoUsuario { get; set; }

        [Column("forzarClave")]
        public bool ForzarClave { get; set; }
        [JsonIgnore]
        public Carrera? Carrera { get; set; }
        [JsonIgnore]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}

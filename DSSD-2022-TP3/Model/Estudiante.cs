using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSSD_2022_TP3.Model
{
    [Table("estudiantes")]
    public class Estudiante
    {   /// <summary>
        /// Id que identifica al estudiante
        /// </summary>
        ///
        [Key]
        [Column("idEstudiante")]
        public int IdEstudiante { get; set; }
        /// <summary>
        /// nombre que identifica al estudiante
        /// </summary>
        [Column("nombre")]
        public string Nombre { get; set; }
        /// <summary>
        /// apellido que identifica al estudiante
        /// </summary>
        [Column("apellido")]
        public string Apellido { get; set; }
        /// <summary>
        /// dni que identifica al estudiante
        /// </summary>
        [Column("dni")]
        public string Dni { get; set; }
        /// <summary>
        /// usuario que identifica al estudiante (basado en el nombre y apellido de la persona)
        /// </summary>
        [Column("usuario")]
        public string? Usuario { get; set; }
        /// <summary>
        /// clave que identifica al estudiante (contraseña temporal de un solo uso que debe cambiarse al ingresar al sistema por primera vez) 
        /// </summary>
        [Column("clave")]
        public string? Clave { get; set; }
        /// <summary>
        /// correo como dato de contacto del estudiante
        /// </summary>
        [Column("correo")]
        public string? Correo { get; set; }
        /// <summary>
        /// celular como dato de contacto del estudiante
        /// </summary>
        [Column("celular")]
        public string Celular { get; set; }

        [Column("forzarClave")]
        public bool ForzarClave { get; set; }
    }
}

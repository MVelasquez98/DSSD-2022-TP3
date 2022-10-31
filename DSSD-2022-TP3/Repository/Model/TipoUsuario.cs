using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSSD_2022_TP3.Model
{
    [Table("tipos_de_usuario")]
    public class TipoUsuario
    {
        /// <summary>
        /// ID que refiere a un tipo de usuario
        /// </summary>
        [Key]
        [Column("idTipoUsuario")]
        public int IdTipoUsuario { get; set; }
        /// <summary>
        /// Cadena que almacena la denominacion del tipo de usuario
        /// </summary>
        [Column("tipoUsuario")]
        public string Nombre { get; set; }
    }
}

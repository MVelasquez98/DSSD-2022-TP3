using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSSD_2022_TP3.Model
{
    [Table("tipos_de_usuario")]
    public class TipoUsuario
    {
        /// <summary>
        /// Id que identifica al Tipo de Usuario
        /// </summary>
        [Key]
        [Column("idTipoUsuario")]
        public int IdTipoUsuario { get; set; }
        /// <summary>
        /// nombre que identifica al tipo de Usuario
        /// </summary>
        [Column("tipoUsuario")]
        public string Nombre { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSSD_2022_TP3.Model
{
    [Table("tipos_nota")]
    public class TipoNota
    {
        /// <summary>
        /// ID que refiere a un tipo de nota
        /// </summary>
        [Key]
        [Column("idTipoNota")]
        public int Id { get; set; }
        /// <summary>
        /// Cadena que almacena la denominacion del tipo de nota
        /// </summary>
        [Column("tipoNota")]
        public string Nombre { get; set; }
    }
}

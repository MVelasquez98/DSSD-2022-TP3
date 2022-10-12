using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSSD_2022_TP3.Model
{
    [Table("tipos_nota")]
    public class TipoNota
    {
        [Key]
        [Column("idTipoNota")]
        public int Id { get; set; }
        [Column("tipoNota")]
        public string Nombre { get; set; }
    }
}

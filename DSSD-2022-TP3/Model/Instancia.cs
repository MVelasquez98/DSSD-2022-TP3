using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSSD_2022_TP3.Model
{
    [Table("instancias")]
    public class Instancia
    {
        /// <summary>
        /// Id que identifica a la instancia
        /// </summary>
        [Key]
        [Column("idInstancia")]
        public int IdInstancia { get; set; }
        /// <summary>
        /// nombre que identifica a la instancia
        /// </summary>
        [Column("instancia")]
        public string Nombre { get; set; }
    }
}

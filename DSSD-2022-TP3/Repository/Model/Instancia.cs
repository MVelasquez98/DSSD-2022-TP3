using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSSD_2022_TP3.Model
{
    [Table("instancias")]
    public class Instancia
    {
        /// <summary>
        /// ID que refiere a la instancia de inscripción
        /// </summary>
        [Key]
        [Column("idInstancia")]
        public int IdInstancia { get; set; }
        /// <summary>
        /// Cadena que almacena de denominación de la instancia de inscripción
        /// </summary>
        [Column("instancia")]
        public string Nombre { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSSD_2022_TP3.Model
{
    [Table("carreras")]
    public class Carrera
    {
        /// <summary>
        /// ID que refiere a una carrera
        /// </summary>
        [Key]
        [Column("idCarrera")]
        public int IdCarrera { get; set; }
        /// <summary>
        /// Cadena que almacena el nombre de la carrera
        /// </summary>
        [Column("carrera")]
        public string Nombre { get; set; }
    }
}

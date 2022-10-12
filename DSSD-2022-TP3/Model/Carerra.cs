using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSSD_2022_TP3.Model
{
    [Table("carreras")]
    public class Carrera
    {
        /// <summary>
        /// Id que identifica a la carrera
        /// </summary>
        [Key]
        [Column("idCarrera")]
        public int IdCarrera { get; set; }
        /// <summary>
        /// nombre que identifica a la carrera
        /// </summary>
        [Column("carrera")]
        public string Nombre { get; set; }
    }
}

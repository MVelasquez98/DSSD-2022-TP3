using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSSD_2022_TP3.Model
{
    [Table("dias")]
    public class Dia
    {
        /// <summary>
        /// Id que identifica al dia
        /// </summary>
        [Key]
        [Column("idDia")]
        public int IdDia { get; set; }
        /// <summary>
        /// nombre que identifica al dia
        /// </summary>
        [Column("dia")]
        public string Nombre { get; set; }
    }
}

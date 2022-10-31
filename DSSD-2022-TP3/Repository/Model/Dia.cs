using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSSD_2022_TP3.Model
{
    [Table("dias")]
    public class Dia
    {
        /// <summary>
        /// ID que refiere a un dia de la semana
        /// </summary>
        [Key]
        [Column("idDia")]
        public int IdDia { get; set; }
        /// <summary>
        /// Cadena que almacena el dia de la semana
        /// </summary>
        [Column("dia")]
        public string Nombre { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSSD_2022_TP3.Model
{
    [Table("turnos")]
    public class Turno
    {
        /// <summary>
        /// Id que identifica al turno
        /// </summary>
        [Key]
        [Column("idTurno")]
        public int IdTurno { get; set; }
        /// <summary>
        /// nombre que identifica al turno
        /// </summary>
        [Column("turno")]
        public string Nombre { get; set; }
    }
}

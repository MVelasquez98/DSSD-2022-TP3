using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSSD_2022_TP3.Model
{
    [Table("turnos")]
    public class Turno
    {
        /// <summary>
        /// ID que refiere a un turno
        /// </summary>
        [Key]
        [Column("idTurno")]
        public int IdTurno { get; set; }
        /// <summary>
        /// Cadena que almacena la denominacion del turno
        /// </summary>
        [Column("turno")]
        public string Nombre { get; set; }
    }
}

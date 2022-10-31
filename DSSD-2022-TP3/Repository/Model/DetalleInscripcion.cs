using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSSD_2022_TP3.Model
{
    [Table("detalle_inscripcion")]
    public class DetalleInscripcion
    {
        /// <summary>
        /// ID que refiere a una inscripcion a comision
        /// </summary>
        [Key]
        [Column("idDetalleInscripcion")]
        public int Id { get; set; }
        /// <summary>
        /// ID que refiere a un llamado a inscripcion
        /// </summary>
        [Column("idInscripcion")]
        public int IdInscripcion { get; set; }
        /// <summary>
        /// ID que refiere a una comision
        /// </summary>
        [Column("idComision")]
        public int IdComision { get; set; }
        /// <summary>
        /// ID que refiere a un usuario del tipo estudiante
        /// </summary>
        [Column("idUsuario")]
        public int IdUsuario { get; set; }
        /// <summary>
        /// Cadena que almacena la fecha en la que se efectuo la inscripcion a comision
        /// </summary>
        [Column("fechaInscripcion")]
        public string FechaInscripcion { get; set; }
        /// <summary>
        /// Boolean que almacena el estado del registro de inscripcion a comision
        /// </summary>
        [Column("baja")]
        public bool Baja { get; set; }
        public Inscripcion Inscripcion { get; set; }
        public Comision Comision { get; set; }
        public Usuario Usuario { get; set; }

    }
}

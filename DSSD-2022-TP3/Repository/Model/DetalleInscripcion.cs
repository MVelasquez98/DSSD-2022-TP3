using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSSD_2022_TP3.Model
{
    [Table("detalle_inscripcion")]
    public class DetalleInscripcion
    {
        [Key]
        [Column("idDetalleInscripcion")]
        public int Id { get; set; }
        [Column("idInscripcion")]
        public int IdInscripcion { get; set; }
        [Column("idComision")]
        public int IdComision { get; set; }
        [Column("idUsuario")]
        public int IdUsuario { get; set; }
        [Column("fechaInscripcion")]
        public string FechaInscripcion { get; set; }
        [Column("baja")]
        public bool Baja { get; set; }
        public Inscripcion Inscripcion { get; set; }
        public Comision Comision { get; set; }
        public Usuario Usuario { get; set; }

    }
}

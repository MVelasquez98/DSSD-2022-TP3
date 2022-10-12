using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSSD_2022_TP3.Model
{
    [Table("historial_academico")]
    public class HistorialAcademico
    {
        [Key]
        [Column("idHistorialAcademico")]
        public int Id { get; set; }
        [Column("idUsuario")]
        public int IdUsuario { get; set; }
        [Column("idComsion")]
        public int IdComsion { get; set; }
        [Column("nota")]
        public int Nota { get; set; }
        [Column("fecha")]
        public string Fecha { get; set; }
        public Usuario Usuario { get; set; }
        public Comision Comision { get; set; }
    }
}

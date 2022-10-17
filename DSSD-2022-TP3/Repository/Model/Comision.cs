using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSSD_2022_TP3.Model
{
    [Table("comisiones")]
    public class Comision
    {
        /// <summary>
        /// Id que identifica a la comision
        /// </summary>
        [Key]
        [Column("idComision")]
        public int IdComision { get; set; }

        [Column("idInscripcion")]
        public int IdInscripcion { get; set; }
        [Column("idTurno")]
        public int? IdTurno { get; set; }
        [Column("idMateria")]
        public int IdMateria { get; set; }
        [Column("idUsuario")]
        public int IdUsuario { get; set; }
        [Column("idDia")]
        public int? IdDia { get; set; }
        [Column("rangoHorario")]
        public string RangoHorario { get; set; }
        [Column("comision")]
        public int NroComision { get; set; }
        [Column("anio")]
        public string Anio { get; set; }
        [Column("fecha")]
        public string Fecha { get; set; }
        public Inscripcion Inscripcion { get; set; }
        public Turno? Turno { get; set; }
        public Materia Materia { get; set; }
        public Usuario Usuario { get; set; }
        public Dia? Dia { get; set; }

    }
}

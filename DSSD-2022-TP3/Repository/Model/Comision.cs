using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSSD_2022_TP3.Model
{
    [Table("comisiones")]
    public class Comision
    {
        /// <summary>
        /// ID que refiere a una comision
        /// </summary>
        [Key]
        [Column("idComision")]
        public int IdComision { get; set; }
        /// <summary>
        /// ID que refiere a un llamado a inscripcion
        /// </summary>
        [Column("idInscripcion")]
        public int IdInscripcion { get; set; }
        /// <summary>
        /// ID que refiere a un turno
        /// </summary>
        [Column("idTurno")]
        public int? IdTurno { get; set; }
        /// <summary>
        /// ID que refiere a una materia
        /// </summary>
        [Column("idMateria")]
        public int IdMateria { get; set; }
        /// <summary>
        /// ID que refiere a un usuario del tipo docente
        /// </summary>
        [Column("idUsuario")]
        public int IdUsuario { get; set; }
        /// <summary>
        /// ID que refiere a un dia de la semana
        /// </summary>
        [Column("idDia")]
        public int? IdDia { get; set; }
        /// <summary>
        /// Cadena que almacena el horario de cursada u horario de inicio de mesa de exámen
        /// </summary>
        [Column("rangoHorario")]
        public string RangoHorario { get; set; }
        /// <summary>
        /// Cadena que almacena el numero de dictado o número de evaluación de la materia
        /// </summary>
        [Column("comision")]
        public int NroComision { get; set; }
        /// <summary>
        /// Cadena que almacena el año correspondiente al ciclo lectivo de la comision
        /// </summary>
        [Column("anio")]
        public string Anio { get; set; }
        /// <summary>
        /// Cadena que almacena fecha de inicio de cursada o fecha de mesa de exámen
        /// </summary>
        [Column("fecha")]
        public string? Fecha { get; set; }
        public Inscripcion Inscripcion { get; set; }
        public Turno? Turno { get; set; }
        public Materia Materia { get; set; }
        public Usuario Usuario { get; set; }
        public Dia? Dia { get; set; }

    }
}

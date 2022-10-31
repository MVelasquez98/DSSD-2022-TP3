using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DSSD_2022_TP3.Model
{
    [Table("inscripciones")]
    public class Inscripcion
    {
        /// <summary>
        /// ID que refiere a un llamado a inscripción
        /// </summary>
        [Key]
        [Column("idInscripcion")]
        public int IdInscripcion { get; set; }

        /// <summary>
        /// ID que refiere a una instancia de inscripción
        /// </summary>
        [Column("idInstancia")]
        public int IdInstancia { get; set; }
        /// <summary>
        /// Cadena que almacena la denominación del llamado a inscripción
        /// </summary>
        [Column("descripcion")]
        public string Descripcion { get; set; }
        /// <summary>
        /// Cadena que almacena la fecha de inicio del llamado de inscripción
        /// </summary>
        [Column("desde")]
        public string Desde { get; set; }
        /// <summary>
        /// Cadena que almacena la fecha de finalización del llamado de inscrición
        /// </summary>
        [Column("hasta")]
        public string Hasta { get; set; }
        /// <summary>
        /// Cadena que almacena la fecha de inicio para la carga de notas
        /// </summary>
        [Column("fechaInicio")]
        public string FechaInicio { get; set; }
        /// <summary>
        /// Cadena que almacena la fecha de cierre para la carga de notas
        /// </summary>
        [Column("fechaFin")]
        public string FechaFin { get; set; }
        /// <summary>
        /// Cadena que almacena el año correspondiente al ciclo lectivo del llamado a inscripción
        /// </summary>
        [Column("anio")]
        public string Anio { get; set; }
        [JsonIgnore]
        public Instancia? Instancia { get; set; }
    }
}

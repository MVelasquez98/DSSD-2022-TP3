using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DSSD_2022_TP3.Model
{
    [Table("inscripciones")]
    public class Inscripcion
    {
        /// <summary>
        /// Id que identifica a la inscripcion
        /// </summary>
        [Key]
        [Column("idInscripcion")]
        public int IdInscripcion { get; set; }

        /// <summary>
        /// Id que identifica a la instancia
        /// </summary>
        [Column("idInstancia")]
        public int IdInstancia { get; set; }
        /// <summary>
        /// descripcion de la inscripcion
        /// </summary>
        [Column("descripcion")]
        public string Descripcion { get; set; }
        [Column("desde")]
        public string Desde { get; set; }
        [Column("hasta")]
        public string Hasta { get; set; }
        [Column("fechaInicio")]
        public string FechaInicio { get; set; }
        [Column("fechaFin")]
        public string FechaFin { get; set; }
        [Column("anio")]
        public string Anio { get; set; }
        [JsonIgnore]
        public Instancia? Instancia { get; set; }
    }
}

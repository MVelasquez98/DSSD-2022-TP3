using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DSSD_2022_TP3.Model
{
    [Table("materias")]
    public class Materia
    {
        /// <summary>
        /// Id que identifica a la materia
        /// </summary>
        [Key]
        [Column("idMateria")]
        public int IdMateria { get; set; }
        /// <summary>
        /// Id que identifica a la carrera de la materia
        /// </summary>
        [Column("idCarrera")]
        public int IdCarrera { get; set; }
        /// <summary>
        /// nombre que identifica a la materia
        /// </summary>
        [Column("nombre")]
        public string Nombre { get; set; }
        /// <summary>
        /// Año de la Carrera
        /// </summary>
        [Column("anioCarrera")]
        public int AnioCarrera { get; set; }

        [JsonIgnore]
        public Carrera Carrera { get; set; }
    }
}

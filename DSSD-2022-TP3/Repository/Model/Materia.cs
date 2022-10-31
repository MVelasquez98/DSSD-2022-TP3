using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DSSD_2022_TP3.Model
{
    [Table("materias")]
    public class Materia
    {
        /// <summary>
        /// ID que refiere a una materia
        /// </summary>
        [Key]
        [Column("idMateria")]
        public int IdMateria { get; set; }
        /// <summary>
        /// ID que refiere a una carrera
        /// </summary>
        [Column("idCarrera")]
        public int IdCarrera { get; set; }
        /// <summary>
        /// Cadena que almacena la denominacion de la materia
        /// </summary>
        [Column("materia")]
        public string Nombre { get; set; }
        /// <summary>
        /// Cadena que almacena el año al cual pertenece la materia dentro del plan de estudio
        /// </summary>
        [Column("anioCarrera")]
        public int AnioCarrera { get; set; }

        [JsonIgnore]
        public Carrera Carrera { get; set; }
    }
}

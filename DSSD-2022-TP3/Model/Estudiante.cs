using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSSD_2022_TP3.Model
{
    [Table ("estudiantes")]
    public class Estudiante
    {
        [Key]
        [Column ("id")]
        public int IdEstudiante { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }
        [Column("apellido")]
        public string Apellido { get; set; }
        [Column("dni")]
        public string Dni { get; set; }
        [Column("usuario")]
        public string Usuario { get; set; }
        [Column("clave")]
        public string Clave { get; set; }
        [Column("mail")]
        public string Mail { get; set; }
        [Column("celular")]
        public string Celular { get; set; }
    }
}

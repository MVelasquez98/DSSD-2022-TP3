using Newtonsoft.Json;

namespace DSSD_2022_TP3.Model
{
    public class DetalleInscripcionDTO
    {
        [JsonProperty("idMateria")]
        public int IdMateria { get; set; }
        [JsonProperty("nombreMateria")]
        public string NombreMateria { get; set; }
        [JsonProperty("alumnos")]
        public List<AlumnoDto> Alumnos { get; set; }
    }
}

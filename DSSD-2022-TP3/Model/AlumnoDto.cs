using Newtonsoft.Json;

namespace DSSD_2022_TP3.Model
{
    public class AlumnoDto
    {
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("apellido")]
        public string Apellido { get; set; }
    }
}
using DSSD_2022_TP3.Model;
using Newtonsoft.Json;

namespace DSSD_2022_TP3.Model
{
    public class ComisionResponse
    {
        [JsonProperty("materia")]
        public string Materia { get; set; }
        [JsonProperty("dia")]
        public string Dia { get; set; }
        [JsonProperty("horario")]
        public string Horario { get; set; }
        [JsonProperty("turno")]
        public string Turno { get; set; }
        [JsonProperty("docente")]
        public string Docente { get; set; }
        [JsonProperty("anio")]
        public string Anio { get; set; }
        [JsonProperty("cuatrimestre")]
        public int Cuatrimestre { get; set; }
    }
}

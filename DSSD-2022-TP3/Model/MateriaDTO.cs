using Newtonsoft.Json;

namespace DSSD_2022_TP3.Model
{
    public class MateriaDTO
    {
        [JsonProperty("idMateria")]
        public int IdMateria { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("carrera")]
        public string Carrera { get; set; }
        [JsonProperty("turno")]
        public string Turno { get; set; }
        [JsonProperty("rangoHorario")]
        public string RangoHorario { get; set; }
        [JsonProperty("nroComision")]
        public int NroComision { get; set; }
        [JsonProperty("anioCarrera")]
        public int AnioCarrera { get; set; }
    }
}

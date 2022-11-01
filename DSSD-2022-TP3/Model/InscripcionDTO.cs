using Newtonsoft.Json;

namespace DSSD_2022_TP3.Model
{
    public class InscripcionDTO
    {
        [JsonProperty("idInscripcion")]
        public int IdInscripcion { get; set; }
        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }
        [JsonProperty("desde")]
        public string Desde { get; set; }
        [JsonProperty("fechaFin")]
        public string FechaFin { get; set; }
        [JsonProperty("fechaInicio")]
        public string FechaInicio { get; set; }
        [JsonProperty("hasta")]
        public string Hasta { get; set; }
        [JsonProperty("instancia")]
        public int Instancia { get; set; }
    }
}

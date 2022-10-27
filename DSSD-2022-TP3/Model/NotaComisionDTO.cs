using Newtonsoft.Json;

namespace DSSD_2022_TP3.Model
{
    public class NotaComisionDTO
    {
        [JsonProperty("idComision")]
        public int IdComision { get; set; }
        [JsonProperty("idEstudiante")]
        public int IdEstudiante { get; set; }
        [JsonProperty("idTipoNota")]
        public int IdTipoNota { get; set; }
        [JsonProperty("nota")]
        public float Nota { get; set; }
        [JsonProperty("fecha")]
        public string Fecha { get; set; }
    }
}

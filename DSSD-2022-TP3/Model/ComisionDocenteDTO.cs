using Newtonsoft.Json;

namespace DSSD_2022_TP3.Model
{
    public class ComisionDocenteDTO
    {
        [JsonProperty("idComision")]
        public int IdComision { get; set; }
        [JsonProperty("nombreMateria")]
        public string NombreMateria { get; set; }
        [JsonProperty("descripcionInscripcion")]
        public string DescripcionInscripcion { get; set; }
        [JsonProperty("tipoInstancia")]
        public int TipoInstancia { get; set; }
        [JsonProperty("fechaInicio")]
        public string FechaInicio { get; set; }
        [JsonProperty("fechaFin")]
        public string FechaFin { get; set; }
    }
}

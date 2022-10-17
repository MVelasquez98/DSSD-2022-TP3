using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace DSSD_2022_TP3.Model
{
    public class ComisionDTO
    {
        [JsonProperty("idMateria")]
        public int IdMateria { get; set; }
        [JsonProperty("dia")]
        public int Dia { get; set; }
        [JsonProperty("horaInicio")]
        public string HoraInicio { get; set; }
        [JsonProperty("horaFin")]
        public string HoraFin { get; set; }
        [JsonProperty("idTurno")]
        public int IdTurno { get; set; }
        [JsonProperty("idDocente")]
        public int IdDocente { get; set; }
        [JsonProperty("anio")]
        public string Anio { get; set; }
        [JsonProperty("cuatrimestre")]
        public int Cuatrimestre { get; set; }
        [JsonProperty("idInscripcion")]
        public int IdInscripcion { get; set; }
        [JsonProperty("fecha")]
        public string Fecha { get; set; }
    }
}

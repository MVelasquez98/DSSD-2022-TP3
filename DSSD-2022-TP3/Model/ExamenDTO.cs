using Newtonsoft.Json;

namespace DSSD_2022_TP3.Model
{
    public class ExamenDTO
    {
        [JsonProperty("idMateria")]
        public int IdMateria { get; set; }
        [JsonProperty("idDocente")]
        public int IdDocente { get; set; }
        [JsonProperty("anio")]
        public string Anio { get; set; }
        [JsonProperty("cuatrimestre")]
        public int Cuatrimestre { get; set; }
        [JsonProperty("fecha")]
        public string Fecha { get; set; }
        /// <summary>
        /// Hora de inicio de examen con formato "hh:mm"
        /// </summary>
        [JsonProperty("horaInicio")]
        public string HoraInicio { get; set; }
        [JsonProperty("idInscripcion")]
        public int IdInscripcion { get; set; }
    }
}

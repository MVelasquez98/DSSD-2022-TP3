using Newtonsoft.Json;

namespace DSSD_2022_TP3.Model
{
    public class AlumnoDto
    {
        [JsonProperty("idEstudiante")]
        public int IdEstudiante { get; set; }
        [JsonProperty("dni")]
        public string Dni { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("apellido")]
        public string Apellido { get; set; }
        [JsonProperty("primer_parcial")]
        public string PrimerParcial { get; set; }
        [JsonProperty("segundo_parcial")]
        public string SegundoParcial { get; set; }
        [JsonProperty("nota_cursada")]
        public string NotaCursada { get; set; }
        [JsonProperty("nota_final")]
        public string NotaFinal { get; set; }
        [JsonProperty("nota_definitiva")]
        public string NotaDefinitiva { get; set; }

    }
}
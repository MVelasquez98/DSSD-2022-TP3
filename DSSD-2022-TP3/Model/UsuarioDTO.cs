using Newtonsoft.Json;

namespace DSSD_2022_TP3.Model
{
    public class UsuarioDTO
    {
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("apellido")]
        public string Apellido { get; set; }
        [JsonProperty("dni")]
        public string Dni { get; set; }
        [JsonProperty("correo")]
        public string Correo { get; set; }
        [JsonProperty("celular")]
        public string Celular { get; set; }
        [JsonProperty("idCarrera")]
        public int IdCarrera { get; set; }
        [JsonProperty("IdTipoUsuario")]
        public int IdTipoUsuario { get; set; }
    }
}

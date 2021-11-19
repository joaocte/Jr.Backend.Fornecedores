using Newtonsoft.Json;

namespace Jr.Backend.Fornecedores.Infrastructure.Services.Model.ApiBrasil
{
    public class CnaesSecundario
    {
        [JsonProperty("codigo")]
        public int Codigo { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }
    }
}
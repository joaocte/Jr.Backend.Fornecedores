using Newtonsoft.Json;
using System;

namespace Jr.Backend.Fornecedores.Infrastructure.Services.Model.ApiBrasil
{
    public class Qsa
    {
        [JsonProperty("identificador_de_socio")]
        public int IdentificadorDeSocio { get; set; }

        [JsonProperty("nome_socio")]
        public string NomeSocio { get; set; }

        [JsonProperty("cnpj_cpf_do_socio")]
        public string CnpjCpfDoSocio { get; set; }

        [JsonProperty("codigo_qualificacao_socio")]
        public int CodigoQualificacaoSocio { get; set; }

        [JsonProperty("percentual_capital_social")]
        public int PercentualCapitalSocial { get; set; }

        [JsonProperty("data_entrada_sociedade")]
        public DateTime DataEntradaSociedade { get; set; }

        [JsonProperty("cpf_representante_legal")]
        public string CpfRepresentanteLegal { get; set; }

        [JsonProperty("nome_representante_legal")]
        public string NomeRepresentanteLegal { get; set; }

        [JsonProperty("codigo_qualificacao_representante_legal")]
        public string CodigoQualificacaoRepresentanteLegal { get; set; }
    }
}
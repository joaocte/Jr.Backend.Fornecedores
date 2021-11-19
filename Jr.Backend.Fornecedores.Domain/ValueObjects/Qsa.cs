using System.Text.Json.Serialization;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    public class Qsa
    {
        [JsonConstructor]
        public Qsa(int identificadorDeSocio, string nomeSocio, string cnpjCpfDoSocio, int codigoQualificacaoSocio, int percentualCapitalSocial, string dataEntradaSociedade, object cpfRepresentanteLegal, object nomeRepresentanteLegal, object codigoQualificacaoRepresentanteLegal)
        {
            IdentificadorDeSocio = identificadorDeSocio;
            NomeSocio = nomeSocio;
            CnpjCpfDoSocio = cnpjCpfDoSocio;
            CodigoQualificacaoSocio = codigoQualificacaoSocio;
            PercentualCapitalSocial = percentualCapitalSocial;
            DataEntradaSociedade = dataEntradaSociedade;
            CpfRepresentanteLegal = cpfRepresentanteLegal;
            NomeRepresentanteLegal = nomeRepresentanteLegal;
            CodigoQualificacaoRepresentanteLegal = codigoQualificacaoRepresentanteLegal;
        }

        public int IdentificadorDeSocio { get; private set; }

        public string NomeSocio { get; private set; }

        public string CnpjCpfDoSocio { get; private set; }

        public int CodigoQualificacaoSocio { get; private set; }

        public int PercentualCapitalSocial { get; private set; }

        public string DataEntradaSociedade { get; private set; }

        public object CpfRepresentanteLegal { get; private set; }

        public object NomeRepresentanteLegal { get; private set; }

        public object CodigoQualificacaoRepresentanteLegal { get; private set; }
    }
}
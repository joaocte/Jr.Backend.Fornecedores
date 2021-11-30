using Jror.Backend.Libs.Domain.Abstractions.ValueObject;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    public class Qsa : ValueObject
    {
        [JsonConstructor]
        public Qsa(int identificadorDeSocio, string nomeSocio, string cnpjCpfDoSocio, int codigoQualificacaoSocio, int percentualCapitalSocial, DateTime? dataEntradaSociedade, string cpfRepresentanteLegal, string nomeRepresentanteLegal, string codigoQualificacaoRepresentanteLegal)
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

        public decimal PercentualCapitalSocial { get; private set; }

        public DateTime? DataEntradaSociedade { get; private set; }

        public string CpfRepresentanteLegal { get; private set; }

        public string NomeRepresentanteLegal { get; private set; }

        public string CodigoQualificacaoRepresentanteLegal { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return IdentificadorDeSocio;
            yield return NomeSocio;
            yield return CnpjCpfDoSocio;
            yield return CodigoQualificacaoRepresentanteLegal;
            yield return CodigoQualificacaoSocio;
            yield return PercentualCapitalSocial;
            yield return DataEntradaSociedade;
            yield return CpfRepresentanteLegal;
            yield return NomeRepresentanteLegal;
        }
    }
}
using Jr.Backend.Fornecedores.Domain.ValueObjects.Enums;
using Jr.Backend.Libs.Domain.Abstractions.ValueObject;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    public class InformacoesBancarias : GenericValueObject
    {
        [JsonConstructor]
        public InformacoesBancarias(string banco, string agencia, string conta, TipoConta tipoConta)
        {
            Banco = banco;
            Agencia = agencia;
            Conta = conta;
            TipoConta = tipoConta;
        }

        public string Agencia { get; private set; }
        public string Banco { get; private set; }
        public string Conta { get; private set; }
        public TipoConta TipoConta { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Agencia;
            yield return Banco;
            yield return Conta;
            yield return TipoConta;
        }
    }
}
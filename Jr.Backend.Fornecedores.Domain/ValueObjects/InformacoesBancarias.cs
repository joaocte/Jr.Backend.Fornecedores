using Jr.Backend.Fornecedores.Domain.ValueObjects.Enums;
using Jr.Backend.Libs.Domain.Abstractions.ValueObject;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    public class InformacoesBancarias : GenericValueObject
    {
        public InformacoesBancarias(Banco banco, Agencia agencia, Conta conta, TipoConta tipoConta)
        {
            Banco = banco;
            Agencia = agencia;
            Conta = conta;
            TipoConta = tipoConta;
        }

        public Agencia Agencia { get; private set; }
        public Banco Banco { get; private set; }
        public Conta Conta { get; private set; }
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
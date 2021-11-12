using Jr.Backend.Fornecedores.Domain.ValueObjects.Enums;
using System.Text.Json.Serialization;

namespace Jr.Backend.Fornecedores.Domain.Commands
{
    public class InformacoesBancariasRequest
    {
        public string Agencia { get; private set; }
        public string Banco { get; private set; }
        public string Conta { get; private set; }
        public TipoConta TipoConta { get; private set; }

        [JsonConstructor]
        public InformacoesBancariasRequest(string agencia, string banco, string conta, TipoConta tipoConta)
        {
            Agencia = agencia;
            Banco = banco;
            Conta = conta;
            TipoConta = tipoConta;
        }
    }
}
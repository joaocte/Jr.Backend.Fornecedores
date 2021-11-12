using Jr.Backend.Fornecedores.Domain.ValueObjects;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Tests.TestObjects
{
    public static class EnderecoFactory
    {
        public static Endereco DeveInstanciarUmEndereco()
        {
            return new Endereco("bairro", "cep", "cidade", "complemento", "estado", "logradouro", "numero");
        }

        public static IEnumerable<Endereco> DeveInstanciarUmaListaDeEnderecos(int quantidade)
        {
            List<Endereco> enderecos = new List<Endereco>();
            for (int i = 0; i < quantidade; i++)
            {
                enderecos.Add(DeveInstanciarUmEndereco());
            }

            return enderecos;
        }
    }
}
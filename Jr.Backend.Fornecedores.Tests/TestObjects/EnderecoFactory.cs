using Jr.Backend.Fornecedores.Domain.ValueObjects.Endereco;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Tests.TestObjects
{
    public static class EnderecoFactory
    {
        public static Endereco DeveInstanciarUmEndereco()
        {
            return new EnderecoCobranca("cep", "logradouro", "numero", "Complemento", "Bairro", "Cidade", "Estado");
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
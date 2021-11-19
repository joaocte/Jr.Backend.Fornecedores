using Jr.Backend.Fornecedores.Domain;
using System;
using System.Threading.Tasks;

namespace Jr.Backend.Fornecedores.Infrastructure.Services.Interface
{
    public interface IApiBrasilService : IDisposable
    {
        Task<Fornecedor> ObterInformacoesDaEmpresaPorCnpj(string cnpj);
    }
}
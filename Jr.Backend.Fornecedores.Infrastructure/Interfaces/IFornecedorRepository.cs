using Jr.Backend.Fornecedores.Infrastructure.Entity;
using Jr.Backend.Libs.Domain.Abstractions.Interfaces.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Fornecedores.Infrastructure.Interfaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<bool> ExistsAsync(string cnpj, CancellationToken cancellationToken = default);
    }
}
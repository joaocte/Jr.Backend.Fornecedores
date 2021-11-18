using Jr.Backend.Fornecedores.Domain.Querys.Response;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Fornecedores.Application.UseCase.ObterFornecedor
{
    public interface IObterFornecedorUseCase : IDisposable
    {
        Task<ObterFornecedorResponse> ExecuteAsync(Domain.Querys.Request.ObterFornecedorQuery query, CancellationToken cancellationToken = default);
    }
}
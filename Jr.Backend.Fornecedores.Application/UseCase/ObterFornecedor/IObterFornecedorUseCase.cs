using Jr.Backend.Fornecedores.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Fornecedores.Application.UseCase.ObterFornecedor
{
    public interface IObterFornecedorUseCase : IDisposable
    {
        Task<IEnumerable<Fornecedor>> ExecuteAsync(Domain.Querys.Request.ObterFornecedorQuery query, CancellationToken cancellationToken = default);
    }
}
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Domain.Commands.Response;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Fornecedores.Application.UseCase.AtualizarFornecedor
{
    public interface IAtualizarFornecedorUseCase : IDisposable
    {
        Task<AtualizarFornecedorCommandResponse> ExecuteAsync(AtualizarFornecedorCommand command,
            CancellationToken cancellationToken = default);
    }
}
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Domain.Commands.Response;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Fornecedores.Application.UseCase.CadastrarFornecedor
{
    public interface ICadastrarFornecedorUseCase : IDisposable
    {
        Task<CadastrarFornecedorCommandResponse> ExecuteAsync(CadastrarFornecedorCommand command, CancellationToken cancellationToken = default);
    }
}
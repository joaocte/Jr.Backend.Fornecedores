using Jr.Backend.Fornecedores.Domain.Commands.Reqiest;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using System;
using System.Threading.Tasks;

namespace Jr.Backend.Fornecedores.Application.UseCase.CadastrarFornecedor
{
    public interface ICadastrarFornecedorUseCase : IDisposable
    {
        Task<CadastrarFornecedorCommandResponse> Execute(CadastrarFornecedorCommand command);
    }
}
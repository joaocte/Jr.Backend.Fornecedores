using Jr.Backend.Fornecedores.Application.UseCase.CadastrarFornecedor;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Domain.Commands.Response;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Fornecedores.Application.Handlers
{
    public class CadastrarFornecedorHandler : IRequestHandler<CadastrarFornecedorCommand, CadastrarFornecedorCommandResponse>
    {
        private readonly ICadastrarFornecedorUseCase cadastrarFornecedorUseCase;

        public CadastrarFornecedorHandler(ICadastrarFornecedorUseCase cadastrarFornecedorUseCase)
        {
            this.cadastrarFornecedorUseCase = cadastrarFornecedorUseCase;
        }

        public async Task<CadastrarFornecedorCommandResponse> Handle(CadastrarFornecedorCommand request, CancellationToken cancellationToken)
        {
            return await cadastrarFornecedorUseCase.ExecuteAsync(request, cancellationToken);
        }
    }
}
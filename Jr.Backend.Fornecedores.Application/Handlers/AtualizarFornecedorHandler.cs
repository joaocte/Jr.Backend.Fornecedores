using Jr.Backend.Fornecedores.Application.UseCase.AtualizarFornecedor;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Domain.Commands.Response;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Fornecedores.Application.Handlers
{
    public class AtualizarFornecedorHandler : IRequestHandler<AtualizarFornecedorCommand, AtualizarFornecedorCommandResponse>
    {
        private readonly IAtualizarFornecedorUseCase atualizarFornecedorUseCase;

        public AtualizarFornecedorHandler(IAtualizarFornecedorUseCase atualizarFornecedorUseCase)
        {
            this.atualizarFornecedorUseCase = atualizarFornecedorUseCase;
        }

        public async Task<AtualizarFornecedorCommandResponse> Handle(AtualizarFornecedorCommand request, CancellationToken cancellationToken)
        {
            return await atualizarFornecedorUseCase.ExecuteAsync(request, cancellationToken);
        }
    }
}
using Jr.Backend.Fornecedores.Application.UseCase.ObterFornecedor;
using Jr.Backend.Fornecedores.Domain.Querys.Request;
using Jr.Backend.Fornecedores.Domain.Querys.Response;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Fornecedores.Application.Handlers
{
    public class ObterFornecedorHandler : IRequestHandler<ObterFornecedorQuery, ObterFornecedorResponse>
    {
        private readonly IObterFornecedorUseCase obterFornecedorUseCase;

        public ObterFornecedorHandler(IObterFornecedorUseCase obterFornecedorUseCase)
        {
            this.obterFornecedorUseCase = obterFornecedorUseCase;
        }

        public async Task<ObterFornecedorResponse> Handle(ObterFornecedorQuery request, CancellationToken cancellationToken)
        {
            return await obterFornecedorUseCase.ExecuteAsync(request);
        }
    }
}
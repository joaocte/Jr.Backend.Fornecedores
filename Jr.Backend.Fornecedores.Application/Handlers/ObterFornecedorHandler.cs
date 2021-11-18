using Jr.Backend.Fornecedores.Application.UseCase.ObterFornecedor;
using Jr.Backend.Fornecedores.Domain;
using Jr.Backend.Fornecedores.Domain.Querys.Request;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Fornecedores.Application.Handlers
{
    public class ObterFornecedorHandler : IRequestHandler<ObterFornecedorQuery, IEnumerable<Fornecedor>>
    {
        private readonly IObterFornecedorUseCase obterFornecedorUseCase;

        public ObterFornecedorHandler(IObterFornecedorUseCase obterFornecedorUseCase)
        {
            this.obterFornecedorUseCase = obterFornecedorUseCase;
        }

        public async Task<IEnumerable<Fornecedor>> Handle(ObterFornecedorQuery request, CancellationToken cancellationToken)
        {
            return await obterFornecedorUseCase.ExecuteAsync(request);
        }
    }
}
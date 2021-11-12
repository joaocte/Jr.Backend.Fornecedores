﻿using Jr.Backend.Fornecedores.Application.UseCase.CadastrarFornecedor;
using Jr.Backend.Fornecedores.Domain.Commands.Reqiest;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Fornecedores.Application.Handlers
{
    public class CadastrarFornecedorHandler : IRequestHandler<CadastrarFornecedorCommand, CadastrarFornecedorCommandResponse>
    {
        private readonly ICadastrarFornecedorUseCase cadastrarFornecedorUseCase;

        public async Task<CadastrarFornecedorCommandResponse> Handle(CadastrarFornecedorCommand request, CancellationToken cancellationToken)
        {
            return await cadastrarFornecedorUseCase.ExecuteAsync(request, cancellationToken);
        }
    }
}
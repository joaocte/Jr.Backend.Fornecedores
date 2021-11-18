using AutoMapper;
using Jr.Backend.Fornecedores.Domain;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Domain.Commands.Response;
using Jr.Backend.Fornecedores.Infrastructure.Interfaces;
using Jr.Backend.Libs.Domain.Abstractions.Exceptions;
using Jr.Backend.Libs.Domain.Abstractions.Notifications;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Fornecedores.Application.UseCase.AtualizarFornecedor
{
    public class AtualizarFornecedorValidationUseCase : IAtualizarFornecedorUseCase
    {
        private readonly IAtualizarFornecedorUseCase atualizarFornecedorUseCase;
        private readonly IFornecedorRepository fornecedorRepository;
        private readonly INotificationContext notificationContext;
        private readonly IMapper mapper;

        public AtualizarFornecedorValidationUseCase(INotificationContext notificationContext, IFornecedorRepository fornecedorRepository, IAtualizarFornecedorUseCase atualizarFornecedorUseCase, IMapper mapper)
        {
            this.notificationContext = notificationContext;
            this.fornecedorRepository = fornecedorRepository;
            this.atualizarFornecedorUseCase = atualizarFornecedorUseCase;
            this.mapper = mapper;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<AtualizarFornecedorCommandResponse> ExecuteAsync(AtualizarFornecedorCommand command, CancellationToken cancellationToken = default)
        {
            var fornecedor = mapper.Map<Fornecedor>(command);
            if (fornecedor.Invalid)
            {
                notificationContext.AddNotifications(fornecedor.ValidationResult);
                return default;
            }
            var fornecedorJaCadastrado = await fornecedorRepository.ExistsAsync(command.Cnpj)
                                         && await fornecedorRepository.ExistsAsync(command.Id);
            if (!fornecedorJaCadastrado)
                throw new NotFoundException(
                    $"Cnpj {command.Cnpj} ou Id {command.Id} Não encontrado!");
            return await atualizarFornecedorUseCase.ExecuteAsync(command);
        }
    }
}
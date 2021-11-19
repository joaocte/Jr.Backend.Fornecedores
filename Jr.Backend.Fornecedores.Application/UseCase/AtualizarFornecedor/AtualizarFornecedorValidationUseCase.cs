using AutoMapper;
using Jr.Backend.Fornecedores.Domain;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Domain.Commands.Response;
using Jr.Backend.Fornecedores.Infrastructure.Interfaces;
using Jr.Backend.Libs.Domain.Abstractions.Exceptions;
using Jr.Backend.Libs.Domain.Abstractions.Notifications;
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

        public async Task<AtualizarFornecedorCommandResponse> ExecuteAsync(AtualizarFornecedorCommand command, CancellationToken cancellationToken = default)
        {
            var fornecedor = await fornecedorRepository.GetByIdAsync(command.Id, cancellationToken);

            var fornecedorDomain = mapper.Map<Fornecedor>(fornecedor);

            fornecedorDomain.AdicionarInformacoesCommand(command);
            if (fornecedorDomain.Invalid)
            {
                notificationContext.AddNotifications(fornecedorDomain.ValidationResult);
                return default;
            }
            var fornecedorJaCadastrado = await fornecedorRepository.ExistsAsync(fornecedor.Cnpj)
                                         && await fornecedorRepository.ExistsAsync(command.Id);
            if (!fornecedorJaCadastrado)
                throw new NotFoundException(
                    $"Cnpj {fornecedor.Cnpj} ou Id {command.Id} Não encontrado!");
            return await atualizarFornecedorUseCase.ExecuteAsync(command);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                atualizarFornecedorUseCase?.Dispose();
                fornecedorRepository?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
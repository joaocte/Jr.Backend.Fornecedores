using AutoMapper;
using Jr.Backend.Fornecedores.Domain;
using Jr.Backend.Fornecedores.Domain.Commands.Reqiest;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Infrastructure.Interfaces;
using Jr.Backend.Libs.Domain.Abstractions.Exceptions;
using Jr.Backend.Libs.Domain.Abstractions.Notifications;
using System.Threading.Tasks;

namespace Jr.Backend.Fornecedores.Application.UseCase.CadastrarFornecedor
{
    public class CadastrarFornecedorUseCaseValidation : ICadastrarFornecedorUseCase
    {
        private readonly ICadastrarFornecedorUseCase cadastrarFornecedorUseCase;
        private readonly IFornecedorRepository fornecedorRepository;
        private readonly IMapper mapper;
        private readonly INotificationContext notificationContext;

        public CadastrarFornecedorUseCaseValidation(ICadastrarFornecedorUseCase cadastrarFornecedorUseCase, IFornecedorRepository fornecedorRepository, IMapper mapper, INotificationContext notificationContext)
        {
            this.cadastrarFornecedorUseCase = cadastrarFornecedorUseCase;
            this.fornecedorRepository = fornecedorRepository;
            this.mapper = mapper;
            this.notificationContext = notificationContext;
        }

        public async Task<CadastrarFornecedorCommandResponse> Execute(CadastrarFornecedorCommand command)
        {
            var fornecedorDomain = mapper.Map<Fornecedor>(command);

            if (fornecedorDomain.Invalid)
            {
                notificationContext.AddNotifications(fornecedorDomain.ValidationResult);
                return default;
            }
            var fornecedorJaCadastrado = await fornecedorRepository.ExistsAsync(fornecedorDomain.Cnpj.ToString());

            if (fornecedorJaCadastrado)
                throw new AlreadyRegisteredException($"Fornecedor {fornecedorDomain.Cnpj} já Cadastrado");

            return await cadastrarFornecedorUseCase.Execute(command);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                cadastrarFornecedorUseCase?.Dispose();
                fornecedorRepository?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
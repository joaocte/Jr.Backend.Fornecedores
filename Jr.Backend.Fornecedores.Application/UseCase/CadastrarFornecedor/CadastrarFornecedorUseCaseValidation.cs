﻿using AutoMapper;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Domain.Commands.Response;
using Jr.Backend.Fornecedores.Infrastructure.Interfaces;
using Jr.Backend.Fornecedores.Infrastructure.Services.Interface;
using Jr.Backend.Libs.Domain.Abstractions.Exceptions;
using Jr.Backend.Libs.Domain.Abstractions.Notifications;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Fornecedores.Application.UseCase.CadastrarFornecedor
{
    public class CadastrarFornecedorUseCaseValidation : ICadastrarFornecedorUseCase
    {
        private readonly ICadastrarFornecedorUseCase cadastrarFornecedorUseCase;
        private readonly IFornecedorRepository fornecedorRepository;
        private readonly IMapper mapper;
        private readonly INotificationContext notificationContext;
        private readonly IApiBrasilService service;

        public CadastrarFornecedorUseCaseValidation(ICadastrarFornecedorUseCase cadastrarFornecedorUseCase, IFornecedorRepository fornecedorRepository, IMapper mapper, INotificationContext notificationContext, IApiBrasilService service)
        {
            this.cadastrarFornecedorUseCase = cadastrarFornecedorUseCase;
            this.fornecedorRepository = fornecedorRepository;
            this.mapper = mapper;
            this.notificationContext = notificationContext;
            this.service = service;
        }

        public async Task<CadastrarFornecedorCommandResponse> ExecuteAsync(CadastrarFornecedorCommand command,
            CancellationToken cancellationToken = default)
        {
            var domainFornecedor = await service.ObterInformacoesDaEmpresaPorCnpj(command.Cnpj);

            if (domainFornecedor is null)
                throw new NotFoundException("CPF Não cadastrado na base da receita federal");

            domainFornecedor.AdicionarInformacoesCommand(command);
            if (domainFornecedor.Invalid)
            {
                notificationContext.AddNotifications(domainFornecedor.ValidationResult);
                return default;
            }
            var fornecedorJaCadastrado =
                await fornecedorRepository.ExistsAsync(command.Cnpj, cancellationToken);

            if (fornecedorJaCadastrado)
                throw new AlreadyRegisteredException($"Fornecedor {command.Cnpj} já Cadastrado");

            return await cadastrarFornecedorUseCase.ExecuteAsync(command, cancellationToken);
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
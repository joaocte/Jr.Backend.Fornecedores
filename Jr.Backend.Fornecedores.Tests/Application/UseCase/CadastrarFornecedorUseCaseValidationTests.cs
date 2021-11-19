using AutoMapper;
using Bogus;
using Jr.Backend.Fornecedores.Application.AutoMapper;
using Jr.Backend.Fornecedores.Application.UseCase.CadastrarFornecedor;
using Jr.Backend.Fornecedores.Domain.Commands;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Domain.Commands.Response;
using Jr.Backend.Fornecedores.Domain.ValueObjects.Enums;
using Jr.Backend.Fornecedores.Infrastructure.Interfaces;
using Jr.Backend.Fornecedores.Infrastructure.Services.Interface;
using Jr.Backend.Fornecedores.Tests.TesteObjects;
using Jr.Backend.Libs.Domain.Abstractions.Exceptions;
using Jr.Backend.Libs.Domain.Abstractions.Notifications;
using Jr.Backend.Libs.Domain.Notifications;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace Jr.Backend.Fornecedores.Tests.Application.UseCase
{
    public class CadastrarFornecedorUseCaseValidationTests
    {
        private readonly ICadastrarFornecedorUseCase cadastrarFornecedorUseCase;
        private readonly ICadastrarFornecedorUseCase cadastrarFornecedorUseCaseValidation;
        private readonly IFornecedorRepository fornecedorRepository;
        private readonly IMapper mapper;
        private readonly INotificationContext notificationContext;
        private readonly IApiBrasilService service;

        public CadastrarFornecedorUseCaseValidationTests()
        {
            cadastrarFornecedorUseCase = Substitute.For<ICadastrarFornecedorUseCase>();
            fornecedorRepository = Substitute.For<IFornecedorRepository>();
            service = Substitute.For<IApiBrasilService>();
            notificationContext = new NotificationContext();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfileToDomain());
                mc.AddProfile(new MappingProfileToEntity());
                mc.AddProfile(new MappingProfileToEnvent());
            });
            mapper = mappingConfig.CreateMapper();
            cadastrarFornecedorUseCaseValidation = new CadastrarFornecedorUseCaseValidation(cadastrarFornecedorUseCase,
                fornecedorRepository, mapper, notificationContext, service);
        }

        [Fact]
        public void QuandoReceberUmaRequisicaoValidaEntaoCadastrarOFornecedor()
        {
            var id = Guid.NewGuid();
            var fornecedor = FornecedorFactory.DeveInstanciarUmFornecedorValido();

            var command = new Faker<CadastrarFornecedorCommand>().CustomInstantiator(f =>
                new CadastrarFornecedorCommand(true, "celular", fornecedor.Cnpj, new List<string> { "email@teste.com.br" },
                    new List<string> { "email@teste.com.br" },
                    new InformacoesBancariasRequest("agencia", "banco", "conta", TipoConta.ContaCorrente),
                    "nomeContato")).Generate();
            service.ObterInformacoesDaEmpresaPorCnpj(fornecedor.Cnpj).Returns(fornecedor);
            cadastrarFornecedorUseCase.ExecuteAsync(command).Returns(new CadastrarFornecedorCommandResponse(id));

            fornecedorRepository.ExistsAsync(Arg.Any<String>()).ReturnsForAnyArgs(false);
            var retorno = cadastrarFornecedorUseCaseValidation.ExecuteAsync(command).Result;

            cadastrarFornecedorUseCase.Received(1).ExecuteAsync(command);
            fornecedorRepository.Received(1).ExistsAsync(Arg.Any<string>());
            Assert.IsType<CadastrarFornecedorCommandResponse>(retorno);
        }

        [Fact]
        public void QuandoReceberUmaRequisicaoValidaDeUmFornecedorJaCadastradoThrowAlreadyRegisteredException()
        {
            var id = Guid.NewGuid();
            var fornecedor = FornecedorFactory.DeveInstanciarUmFornecedorValido();

            var command = new Faker<CadastrarFornecedorCommand>().CustomInstantiator(f =>
                new CadastrarFornecedorCommand(true, "celular", fornecedor.Cnpj, new List<string> { "email@teste.com.br" },
                    new List<string> { "email@teste.com.br" },
                    new InformacoesBancariasRequest("agencia", "banco", "conta", TipoConta.ContaCorrente),
                    "nomeContato")).Generate();
            service.ObterInformacoesDaEmpresaPorCnpj(fornecedor.Cnpj).Returns(fornecedor);

            cadastrarFornecedorUseCase.ExecuteAsync(command).Returns(new CadastrarFornecedorCommandResponse(id));
            fornecedorRepository.ExistsAsync(command.Cnpj).Returns(true);
            Assert.ThrowsAsync<AlreadyRegisteredException>(() =>
                 cadastrarFornecedorUseCaseValidation.ExecuteAsync(command));

            cadastrarFornecedorUseCase.DidNotReceive().ExecuteAsync(command);
            fornecedorRepository.Received(1).ExistsAsync(Arg.Any<string>());
        }

        [Fact]
        public void QuandoReceberUmaRequisicaoInvalidaValidaEntaoCadastrarOFornecedor()
        {
            var id = Guid.NewGuid();
            var fornecedor = FornecedorFactory.DeveInstanciarUmFornecedorInvalido();

            var command = new Faker<CadastrarFornecedorCommand>().CustomInstantiator(f =>
                new CadastrarFornecedorCommand(true, "celular", fornecedor.Cnpj, new List<string> { "email@teste.com.br" },
                    new List<string> { },
                    new InformacoesBancariasRequest("", "", "", TipoConta.ContaCorrente),
                    "nomeContato")).Generate();
            service.ObterInformacoesDaEmpresaPorCnpj(fornecedor.Cnpj).Returns(fornecedor);
            var retorno = cadastrarFornecedorUseCaseValidation.ExecuteAsync(command).Result;

            cadastrarFornecedorUseCase.DidNotReceive().ExecuteAsync(command);
            fornecedorRepository.Received(1).ExistsAsync(Arg.Any<string>());
            service.Received(1).ObterInformacoesDaEmpresaPorCnpj(fornecedor.Cnpj);
            Assert.Null(retorno);
        }
    }
}
﻿using AutoMapper;
using Jr.Backend.Fornecedores.Application.UseCase.CadastrarFornecedor;
using Jr.Backend.Fornecedores.Domain.Commands.Reqiest;
using Jr.Backend.Fornecedores.Infrastructure.Interfaces;
using Jr.Backend.Fornecedores.Tests.TestObjects;
using Jr.Backend.Libs.Domain.Abstractions.Exceptions;
using Jr.Backend.Libs.Domain.Notifications;
using Jr.Backend.Pessoa.Application.AutoMapper;
using NSubstitute;
using System;
using Xunit;

namespace Jr.Backend.Fornecedores.Tests.Application.UseCase
{
    public class CadastrarFornecedorUseCaseValidationTests
    {
        private readonly ICadastrarFornecedorUseCase cadastrarFornecedorUseCase;
        private readonly ICadastrarFornecedorUseCase cadastrarFornecedorUseCaseValidation;
        private readonly IFornecedorRepository fornecedorRepository;
        private readonly IMapper mapper;
        private readonly NotificationContext notificationContext;

        public CadastrarFornecedorUseCaseValidationTests()
        {
            cadastrarFornecedorUseCase = Substitute.For<ICadastrarFornecedorUseCase>();
            fornecedorRepository = Substitute.For<IFornecedorRepository>();
            notificationContext = new NotificationContext();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfileToDomain());
                mc.AddProfile(new MappingProfileToEntity());
            });
            mapper = mappingConfig.CreateMapper();
            cadastrarFornecedorUseCaseValidation = new CadastrarFornecedorUseCaseValidation(cadastrarFornecedorUseCase,
                fornecedorRepository, mapper, notificationContext);
        }

        [Fact]
        public void QuandoReceberUmaRequisicaoValidaEntaoCadastrarOFornecedor()
        {
            var id = Guid.NewGuid();
            var command = CommandFactory.GerarCadastrarFornecedorCommandValido();

            cadastrarFornecedorUseCase.Execute(command).Returns(new CadastrarFornecedorCommandResponse(id));
            fornecedorRepository.ExistsAsync(Arg.Any<String>()).ReturnsForAnyArgs(false);
            var retorno = cadastrarFornecedorUseCaseValidation.Execute(command).Result;

            cadastrarFornecedorUseCase.Received(1).Execute(command);
            fornecedorRepository.Received(1).ExistsAsync(Arg.Any<string>());
            Assert.IsType<CadastrarFornecedorCommandResponse>(retorno);
        }

        [Fact]
        public void QuandoReceberUmaRequisicaoValidaDeUmFornecedorJaCadastradoThrowAlreadyRegisteredException()
        {
            var id = Guid.NewGuid();
            var command = CommandFactory.GerarCadastrarFornecedorCommandValido();

            cadastrarFornecedorUseCase.Execute(command).Returns(new CadastrarFornecedorCommandResponse(id));
            fornecedorRepository.ExistsAsync(command.Cnpj.ToString()).Returns(true);
            Assert.ThrowsAsync<AlreadyRegisteredException>(() =>
                 cadastrarFornecedorUseCaseValidation.Execute(command));

            cadastrarFornecedorUseCase.DidNotReceive().Execute(command);
            fornecedorRepository.Received(1).ExistsAsync(Arg.Any<string>());
        }

        [Fact]
        public void QuandoReceberUmaRequisicaoInvalidaValidaEntaoCadastrarOFornecedor()
        {
            var id = Guid.NewGuid();
            var command = CommandFactory.GerarCadastrarFornecedorCommandInValido();

            var retorno = cadastrarFornecedorUseCaseValidation.Execute(command).Result;

            cadastrarFornecedorUseCase.DidNotReceive().Execute(command);
            fornecedorRepository.DidNotReceive().ExistsAsync(Arg.Any<string>());
            Assert.Null(retorno);
            Assert.NotNull(notificationContext);
        }
    }
}
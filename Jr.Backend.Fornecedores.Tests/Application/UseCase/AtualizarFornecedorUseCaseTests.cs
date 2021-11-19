using AutoBogus;
using AutoMapper;
using Jr.Backend.Fornecedores.Application.AutoMapper;
using Jr.Backend.Fornecedores.Application.UseCase.AtualizarFornecedor;
using Jr.Backend.Fornecedores.Domain.Commands;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Domain.ValueObjects.Enums;
using Jr.Backend.Fornecedores.Infrastructure.Interfaces;
using Jr.Backend.Libs.Domain.Abstractions.Interfaces.Repository;
using MassTransit;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace Jr.Backend.Fornecedores.Tests.Application.UseCase
{
    public class AtualizarFornecedorUseCaseTests
    {
        private readonly IAtualizarFornecedorUseCase atualizarFornecedorUseCase;
        private readonly IFornecedorRepository fornecedorRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IBus bus;

        public AtualizarFornecedorUseCaseTests()
        {
            fornecedorRepository = Substitute.For<IFornecedorRepository>();
            unitOfWork = Substitute.For<IUnitOfWork>();
            bus = Substitute.For<IBus>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfileToDomain());
                mc.AddProfile(new MappingProfileToEntity());
                mc.AddProfile(new MappingProfileToEnvent());
                mc.AddProfile(new MappingProfileToResponse());
            });
            mapper = mappingConfig.CreateMapper();
            atualizarFornecedorUseCase = new AtualizarFornecedorUseCase(fornecedorRepository, unitOfWork, mapper, bus);
        }

        [Fact]
        public void QuandoRecerAtualizarFornecedorCommandValidoEntaoRealizarOperacaoComSucesso()
        {
            var id = Guid.NewGuid();
            AtualizarFornecedorCommand command = new AutoFaker<AtualizarFornecedorCommand>().CustomInstantiator(f =>
                new AtualizarFornecedorCommand(true, "celular", "42355973000193", new List<string> { "joaocte@gmail.com" },
                    new List<string> { "joaocte@gmail.com" },
                    new InformacoesBancariasRequest("agencia", "banco", "conta", TipoConta.ContaCorrente),
                    "nomeContato", id)).Generate();

            var response = atualizarFornecedorUseCase.ExecuteAsync(command).Result;

            //bus.Received(1).Publish(Arg.Any<FornecedorAtualizadoEvent>());
            Assert.NotNull(response);
            Assert.Equal(id, response.Id);
        }
    }
}
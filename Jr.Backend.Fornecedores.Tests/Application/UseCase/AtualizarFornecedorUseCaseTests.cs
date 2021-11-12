using AutoMapper;
using Jr.Backend.Fornecedores.Application.AutoMapper;
using Jr.Backend.Fornecedores.Application.UseCase.AtualizarFornecedor;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Infrastructure.Interfaces;
using Jr.Backend.Fornecedores.Tests.TestObjects;
using Jr.Backend.Libs.Domain.Abstractions.Interfaces.Repository;
using Jr.Backend.Message.Events.Fornecedor.Events;
using MassTransit;
using NSubstitute;
using System;
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
            var dataCadastro = DateTime.Now.AddDays(-3);
            AtualizarFornecedorCommand command = CommandFactory.GerarAtualizarFornecedorCommandValido(id, dataCadastro);

            var response = atualizarFornecedorUseCase.ExecuteAsync(command).Result;

            bus.Received(1).Publish(Arg.Any<FornecedorAtulizadoEvent>());
            Assert.NotNull(response);
            Assert.Equal(id, response.Id);
            Assert.Equal(dataCadastro, response.DataCadastro);
        }
    }
}
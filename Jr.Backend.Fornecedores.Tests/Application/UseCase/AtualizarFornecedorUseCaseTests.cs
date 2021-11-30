using AutoBogus;
using AutoMapper;
using Jr.Backend.Fornecedores.Application.AutoMapper;
using Jr.Backend.Fornecedores.Application.UseCase.AtualizarFornecedor;
using Jr.Backend.Fornecedores.Domain.Commands;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Domain.ValueObjects.Enums;
using Jr.Backend.Fornecedores.Infrastructure.Interfaces;
using Jr.Backend.Fornecedores.Tests.TesteObjects;
using Jr.Backend.Message.Events.Fornecedor.Events;
using Jror.Backend.Libs.Infrastructure.Data.Shared.Interfaces;
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

            var fornecedor = FornecedorFactory.DeveInstanciarUmFornecedorValido(id, DateTime.Now);
            AtualizarFornecedorCommand command = new AutoFaker<AtualizarFornecedorCommand>().CustomInstantiator(f =>
                new AtualizarFornecedorCommand(fornecedor.Celular, fornecedor.Cnpj, fornecedor.EmailContato,
                    fornecedor.EmailFatura,
                    new InformacoesBancariasRequest("agencia", "banco", "conta", TipoConta.ContaCorrente),
                    fornecedor.NomeContato, fornecedor.Id)).Generate();
            fornecedorRepository.GetByIdAsync(command.Id)
                .Returns(mapper.Map<Infrastructure.Entity.Fornecedor>(fornecedor));
            var response = atualizarFornecedorUseCase.ExecuteAsync(command).Result;

            bus.Received(1).Publish(Arg.Any<FornecedorAtualizadoEvent>());
            fornecedorRepository.Received(1).GetByIdAsync(id);
            fornecedorRepository.Received(1).UpdateAsync(Arg.Any<Infrastructure.Entity.Fornecedor>());
            Assert.NotNull(response);
            Assert.Equal(id, response.Id);
        }
    }
}
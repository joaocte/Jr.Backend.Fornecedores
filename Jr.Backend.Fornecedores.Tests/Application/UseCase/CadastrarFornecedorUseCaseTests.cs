using AutoMapper;
using Jr.Backend.Fornecedores.Application.AutoMapper;
using Jr.Backend.Fornecedores.Application.UseCase.CadastrarFornecedor;
using Jr.Backend.Fornecedores.Domain.Commands.Reqiest;
using Jr.Backend.Fornecedores.Infrastructure.Entity;
using Jr.Backend.Fornecedores.Infrastructure.Interfaces;
using Jr.Backend.Fornecedores.Tests.TestObjects;
using Jr.Backend.Message.Events.Fornecedor.Events;
using MassTransit;
using NSubstitute;
using Xunit;

namespace Jr.Backend.Fornecedores.Tests.Application.UseCase
{
    public class CadastrarFornecedorUseCaseTests
    {
        private readonly IFornecedorRepository fornecedorRepository;
        private readonly ICadastrarFornecedorUseCase cadastrarFornecedorUseCase;
        private readonly IMapper mapper;
        private readonly IBus bus;

        public CadastrarFornecedorUseCaseTests()
        {
            fornecedorRepository = Substitute.For<IFornecedorRepository>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfileToDomain());
                mc.AddProfile(new MappingProfileToEntity());
                mc.AddProfile(new MappingProfileToEnvent());
            });
            mapper = mappingConfig.CreateMapper();

            bus = Substitute.For<IBus>();

            cadastrarFornecedorUseCase = new CadastrarFornecedorUseCase(fornecedorRepository, mapper, bus);
        }

        [Fact]
        public void QuandoReceberUmaRequisicaoValidaEntaoCadastrarOFornecedor()
        {
            var retorno = cadastrarFornecedorUseCase.Execute(CommandFactory.GerarCadastrarFornecedorCommandValido()).Result;
            bus.Received(1).Publish(Arg.Any<FornecedorCadastradoEvent>());
            fornecedorRepository.Received(1).AddAsync(Arg.Any<Fornecedor>());
            Assert.IsType<CadastrarFornecedorCommandResponse>(retorno);
        }
    }
}
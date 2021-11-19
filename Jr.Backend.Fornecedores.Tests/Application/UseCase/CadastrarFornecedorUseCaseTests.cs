using AutoMapper;
using Bogus;
using Jr.Backend.Fornecedores.Application.AutoMapper;
using Jr.Backend.Fornecedores.Application.UseCase.CadastrarFornecedor;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Domain.Commands.Response;
using Jr.Backend.Fornecedores.Infrastructure.Interfaces;
using Jr.Backend.Fornecedores.Infrastructure.Services.Interface;
using Jr.Backend.Libs.Domain.Abstractions.Interfaces.Repository;
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
        private readonly IUnitOfWork unitOfWork;
        private readonly IBus bus;
        private readonly IApiBrasilService service;

        public CadastrarFornecedorUseCaseTests()
        {
            fornecedorRepository = Substitute.For<IFornecedorRepository>();
            unitOfWork = Substitute.For<IUnitOfWork>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfileToDomain());
                mc.AddProfile(new MappingProfileToEntity());
                mc.AddProfile(new MappingProfileToEnvent());
                mc.AddProfile(new MappingProfileToResponse());
            });
            mapper = mappingConfig.CreateMapper();

            service = Substitute.For<IApiBrasilService>();

            bus = Substitute.For<IBus>();

            cadastrarFornecedorUseCase = new CadastrarFornecedorUseCase(fornecedorRepository, mapper, bus, unitOfWork, service);
        }

        [Fact]
        public void QuandoReceberUmaRequisicaoValidaEntaoCadastrarOFornecedor()
        {
            var command = new Faker<CadastrarFornecedorCommand>().RuleFor(x => x.Cnpj, x => "47419051000116").Generate();
            var retorno = cadastrarFornecedorUseCase.ExecuteAsync(command).Result;
            bus.Received(1).Publish(Arg.Any<FornecedorCadastradoEvent>());
            fornecedorRepository.Received(1).AddAsync(Arg.Any<Infrastructure.Entity.Fornecedor>());
            unitOfWork.Received(1).CommitAsync();
            Assert.IsType<CadastrarFornecedorCommandResponse>(retorno);
        }
    }
}
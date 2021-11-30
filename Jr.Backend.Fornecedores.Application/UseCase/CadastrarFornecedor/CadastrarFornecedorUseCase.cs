using AutoMapper;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Domain.Commands.Response;
using Jr.Backend.Fornecedores.Infrastructure.Entity;
using Jr.Backend.Fornecedores.Infrastructure.Interfaces;
using Jr.Backend.Fornecedores.Infrastructure.Services.Interface;
using Jr.Backend.Message.Events.Fornecedor.Events;
using Jror.Backend.Libs.Infrastructure.Data.Shared.Interfaces;
using MassTransit;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Fornecedores.Application.UseCase.CadastrarFornecedor
{
    public class CadastrarFornecedorUseCase : ICadastrarFornecedorUseCase
    {
        private readonly IFornecedorRepository fornecedorRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IBus bus;
        private readonly IApiBrasilService service;

        public CadastrarFornecedorUseCase(IFornecedorRepository fornecedorRepository, IMapper mapper, IBus bus, IUnitOfWork unitOfWork, IApiBrasilService service)
        {
            this.fornecedorRepository = fornecedorRepository;
            this.mapper = mapper;
            this.bus = bus;
            this.unitOfWork = unitOfWork;
            this.service = service;
        }

        public async Task<CadastrarFornecedorCommandResponse> ExecuteAsync(CadastrarFornecedorCommand command, CancellationToken cancellationToken = default)
        {
            var domainFornecedor = await service.ObterInformacoesDaEmpresaPorCnpj(command.Cnpj);

            domainFornecedor.AdicionarInformacoesCommand(command);

            var entityFornecedor = mapper.Map<Fornecedor>(domainFornecedor);

            var taskInsert = fornecedorRepository.AddAsync(entityFornecedor, cancellationToken);
            var taskCommit = unitOfWork.CommitAsync();

            await Task.WhenAll(taskInsert, taskCommit);
            var @event = mapper.Map<FornecedorCadastradoEvent>(entityFornecedor);

            await bus.Publish(@event, cancellationToken);
            return new CadastrarFornecedorCommandResponse(entityFornecedor.Id);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                fornecedorRepository?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
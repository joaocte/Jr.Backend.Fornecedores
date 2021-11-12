using AutoMapper;
using Jr.Backend.Fornecedores.Domain.Commands.Reqiest;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Infrastructure.Entity;
using Jr.Backend.Fornecedores.Infrastructure.Interfaces;
using Jr.Backend.Libs.Domain.Abstractions.Interfaces.Repository;
using Jr.Backend.Message.Events.Fornecedor.Events;
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

        public CadastrarFornecedorUseCase(IFornecedorRepository fornecedorRepository, IMapper mapper, IBus bus, IUnitOfWork unitOfWork)
        {
            this.fornecedorRepository = fornecedorRepository;
            this.mapper = mapper;
            this.bus = bus;
            this.unitOfWork = unitOfWork;
        }

        public async Task<CadastrarFornecedorCommandResponse> ExecuteAsync(CadastrarFornecedorCommand command, CancellationToken cancellationToken = default)
        {
            var entityFornecedor = mapper.Map<Fornecedor>(command);
            await fornecedorRepository.AddAsync(entityFornecedor, cancellationToken);

            await unitOfWork.CommitAsync();
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
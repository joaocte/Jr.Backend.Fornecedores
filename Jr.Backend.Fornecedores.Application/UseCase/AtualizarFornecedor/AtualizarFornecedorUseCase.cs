using AutoMapper;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Domain.Commands.Response;
using Jr.Backend.Fornecedores.Infrastructure.Entity;
using Jr.Backend.Fornecedores.Infrastructure.Interfaces;
using Jr.Backend.Libs.Domain.Abstractions.Interfaces.Repository;
using Jr.Backend.Message.Events.Fornecedor.Events;
using MassTransit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Fornecedores.Application.UseCase.AtualizarFornecedor
{
    public class AtualizarFornecedorUseCase : IAtualizarFornecedorUseCase
    {
        private readonly IFornecedorRepository fornecedorRepository;
        private readonly IUnitOfWork iUnitOfWork;
        private readonly IMapper mapper;
        private readonly IBus bus;

        public AtualizarFornecedorUseCase(IFornecedorRepository fornecedorRepository, IUnitOfWork iUnitOfWork, IMapper mapper, IBus bus)
        {
            this.fornecedorRepository = fornecedorRepository;
            this.iUnitOfWork = iUnitOfWork;
            this.mapper = mapper;
            this.bus = bus;
        }

        public async Task<AtualizarFornecedorCommandResponse> ExecuteAsync(AtualizarFornecedorCommand command, CancellationToken cancellationToken = default)
        {
            Fornecedor fornecedor = mapper.Map<Fornecedor>(command);

            await fornecedorRepository.UpdateAsync(fornecedor, cancellationToken);

            await iUnitOfWork.CommitAsync();

            var @event = mapper.Map<FornecedorAtualizadoEvent>(fornecedor);

            await bus.Publish(@event);

            return mapper.Map<AtualizarFornecedorCommandResponse>(fornecedor);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                fornecedorRepository?.Dispose();
                iUnitOfWork?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
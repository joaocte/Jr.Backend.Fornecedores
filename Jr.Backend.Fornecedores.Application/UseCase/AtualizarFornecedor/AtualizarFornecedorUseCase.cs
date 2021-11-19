using AutoMapper;
using Jr.Backend.Fornecedores.Domain;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Domain.Commands.Response;
using Jr.Backend.Fornecedores.Infrastructure.Interfaces;
using Jr.Backend.Libs.Domain.Abstractions.Interfaces.Repository;
using Jr.Backend.Message.Events.Fornecedor.Events;
using MassTransit;
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
            var fornecedor = await fornecedorRepository.GetAsync(x => x.Cnpj == command.Cnpj, cancellationToken);

            var fornecedorDomain = mapper.Map<Fornecedor>(fornecedor);

            fornecedorDomain.AdicionarInformacoesCommand(command);

            var fornecedorUpdate = mapper.Map<Infrastructure.Entity.Fornecedor>(fornecedorDomain);

            var taskUpdate = fornecedorRepository.UpdateAsync(fornecedorUpdate, cancellationToken);

            var taksCommit = iUnitOfWork.CommitAsync();

            var @event = mapper.Map<FornecedorAtualizadoEvent>(fornecedor);

            var evemtTask = bus.Publish(@event, cancellationToken);

            await Task.WhenAll(taskUpdate, taksCommit, evemtTask);

            return mapper.Map<AtualizarFornecedorCommandResponse>(fornecedorUpdate);
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
        }
    }
}
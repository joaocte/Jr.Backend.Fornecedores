using AutoMapper;
using Jr.Backend.Fornecedores.Domain;
using Jr.Backend.Fornecedores.Infrastructure.Interfaces;
using Jr.Backend.Libs.Domain.Abstractions.Exceptions;
using Jr.Backend.Libs.Extensions;
using ServiceStack;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Fornecedores.Application.UseCase.ObterFornecedor
{
    public class ObterFornecedorUseCase : IObterFornecedorUseCase
    {
        private readonly IFornecedorRepository fornecedorRepository;
        private readonly IMapper mapper;

        public ObterFornecedorUseCase(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            this.fornecedorRepository = fornecedorRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Fornecedor>> ExecuteAsync(Domain.Querys.Request.ObterFornecedorQuery query, CancellationToken cancellationToken = default)
        {
            var fornecedorEntityQueryable = await fornecedorRepository.GetAllAsQueryableAsync(cancellationToken);

            var fornecedoresEntity = fornecedorEntityQueryable.Apply(query).ToList();

            if ((bool)!fornecedoresEntity?.Any())
                throw new NotFoundException($"Não foi encontrado fornecedor para consulta informada.");

            return mapper.Map<IEnumerable<Fornecedor>>(fornecedoresEntity);
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
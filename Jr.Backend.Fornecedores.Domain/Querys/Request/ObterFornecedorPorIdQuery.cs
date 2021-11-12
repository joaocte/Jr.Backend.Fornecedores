using Jr.Backend.Fornecedores.Domain.Querys.Response;
using MediatR;
using System;

namespace Jr.Backend.Fornecedores.Domain.Querys.Request
{
    public class ObterFornecedorPorIdQuery : IRequest<ObterFornecedorPorIdResponse>
    {
        public ObterFornecedorPorIdQuery(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; set; }
    }
}
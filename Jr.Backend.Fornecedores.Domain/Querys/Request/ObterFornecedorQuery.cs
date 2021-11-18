using Jr.Backend.Fornecedores.Domain.Querys.Response;
using Jr.Backend.Libs.Extensions.Pagination;
using Jr.Backend.Libs.Extensions.Sort;
using MediatR;
using System;

namespace Jr.Backend.Fornecedores.Domain.Querys.Request
{
    public class ObterFornecedorQuery : IRequest<ObterFornecedorResponse>, IQuerySort, IQueryPaging
    {
        public Guid Id { get; set; }
        public string Cnpj { get; set; }
        public string Sort { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }
    }
}
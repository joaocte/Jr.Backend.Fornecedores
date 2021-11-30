using AspNetCore.IQueryable.Extensions.Pagination;
using AspNetCore.IQueryable.Extensions.Sort;
using MediatR;
using System;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.Querys.Request
{
    public class ObterFornecedorQuery : IRequest<IEnumerable<Fornecedor>>, IQuerySort, IQueryPaging
    {
        public Guid Id { get; set; }
        public string Cnpj { get; set; }
        public string Sort { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }
    }
}
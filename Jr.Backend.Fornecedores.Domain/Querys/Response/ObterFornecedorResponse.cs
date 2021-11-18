using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.Querys.Response
{
    public class ObterFornecedorResponse
    {
        public ObterFornecedorResponse(IEnumerable<Fornecedor> fornecedores)
        {
            this.Fornecedores = fornecedores;
        }

        private IEnumerable<Fornecedor> Fornecedores { get; set; }
    }
}
using System;

namespace Jr.Backend.Fornecedores.Domain.Commands.Response
{
    public class CadastrarFornecedorCommandResponse
    {
        public CadastrarFornecedorCommandResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
using System;

namespace Jr.Backend.Fornecedores.Domain.Commands.Reqiest
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
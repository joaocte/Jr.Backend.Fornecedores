using System;

namespace Jr.Backend.Fornecedores.Domain.Commands.Reqiest
{
    public class CadastrarPessoaCommandResponse
    {
        public CadastrarPessoaCommandResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
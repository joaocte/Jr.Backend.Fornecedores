using Jr.Backend.Fornecedores.Domain.Commands.Response;
using MediatR;
using System;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.Commands.Request
{
    public class AtualizarFornecedorCommand : FornecedorCommandRequest, IRequest<AtualizarFornecedorCommandResponse>
    {
        public Guid Id { get; }

        public AtualizarFornecedorCommand(bool aceiteTermosDeUso, string celular, string cnpj,
            IEnumerable<string> emailContato, IEnumerable<string> emailFatura,
            InformacoesBancariasRequest informacoesBancarias, string nomeContato, Guid id) : base(aceiteTermosDeUso, celular,
            cnpj, emailContato, emailFatura, informacoesBancarias, nomeContato)
        {
            Id = id;
        }
    }
}
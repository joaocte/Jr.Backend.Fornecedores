using Jr.Backend.Fornecedores.Domain.Commands.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Jr.Backend.Fornecedores.Domain.Commands.Request
{
    public class AtualizarFornecedorCommand : FornecedorCommandRequest, IRequest<AtualizarFornecedorCommandResponse>
    {
        [JsonIgnore]
        public Guid Id { get; }

        public AtualizarFornecedorCommand(string celular, string cnpj, ICollection<string> emailContato, ICollection<string> emailFatura, InformacoesBancariasRequest informacoesBancarias, string nomeContato, Guid id) : base(celular, cnpj, emailContato, emailFatura, informacoesBancarias, nomeContato)
        {
            Id = id;
        }
    }
}
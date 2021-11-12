using Jr.Backend.Fornecedores.Domain.Commands.Response;
using Jr.Backend.Fornecedores.Domain.ValueObjects.Enums;
using MediatR;
using System;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.Commands.Request
{
    public class AtualizarFornecedorCommand : FornecedorCommandRequest, IRequest<AtualizarFornecedorCommandResponse>
    {
        public Guid Id { get; }

        public AtualizarFornecedorCommand(string celular, string cnae, string cnpj, DateTime dataCadastro, IEnumerable<string> emailContato, IEnumerable<string> emailFatura, List<EnderecoRequest> enderecos, InformacoesBancariasRequest informacoesBancarias, string nomeContato, string nomeRazaoSocial, StatusCadastro status, string telefone, bool aceiteTermosDeUso, Guid id) : base(celular, cnae, cnpj, dataCadastro, emailContato, emailFatura, enderecos, informacoesBancarias, nomeContato, nomeRazaoSocial, status, telefone, aceiteTermosDeUso)
        {
            Id = id;
        }
    }
}
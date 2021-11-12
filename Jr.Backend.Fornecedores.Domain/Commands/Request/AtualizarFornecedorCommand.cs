using Jr.Backend.Fornecedores.Domain.Commands.Response;
using Jr.Backend.Fornecedores.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.Commands.Request
{
    public class AtualizarFornecedorCommand : Fornecedor, IRequest<AtualizarFornecedorCommandResponse>
    {
        public AtualizarFornecedorCommand(Celular celular, Cnpj cnpj, IEnumerable<EmailContato> emailContato, IEnumerable<EmailFatura> emailFatura, InformacoesBancarias informacoesBancarias, NomeCompleto nomeRazaoSocial, Telefone telefone, CNAE cnae, NomeCompleto nomeContato, AceiteTermosDeUso aceiteTermosDeUso) : base(celular, cnpj, emailContato, emailFatura, informacoesBancarias, nomeRazaoSocial, telefone, cnae, nomeContato, aceiteTermosDeUso)
        {
        }

        public AtualizarFornecedorCommand(Guid id, Celular celular, Cnpj cnpj, IEnumerable<EmailContato> emailContato, IEnumerable<EmailFatura> emailFatura, InformacoesBancarias informacoesBancarias, NomeCompleto nomeRazaoSocial, Telefone telefone, CNAE cnae, NomeCompleto nomeContato, AceiteTermosDeUso aceiteTermosDeUso, DateTime dataCadastro) : base(id, celular, cnpj, emailContato, emailFatura, informacoesBancarias, nomeRazaoSocial, telefone, cnae, nomeContato, aceiteTermosDeUso, dataCadastro)
        {
        }
    }
}
using Jr.Backend.Fornecedores.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.Commands.Response
{
    public class AtualizarFornecedorCommandResponse : Fornecedor
    {
        public AtualizarFornecedorCommandResponse(Celular celular, Cnpj cnpj, IEnumerable<EmailContato> emailContato, IEnumerable<EmailFatura> emailFatura, InformacoesBancarias informacoesBancarias, NomeCompleto nomeRazaoSocial, Telefone telefone, CNAE cnae, NomeCompleto nomeContato, AceiteTermosDeUso aceiteTermosDeUso) : base(celular, cnpj, emailContato, emailFatura, informacoesBancarias, nomeRazaoSocial, telefone, cnae, nomeContato, aceiteTermosDeUso)
        {
        }

        public AtualizarFornecedorCommandResponse(Guid id, Celular celular, Cnpj cnpj, IEnumerable<EmailContato> emailContato, IEnumerable<EmailFatura> emailFatura, InformacoesBancarias informacoesBancarias, NomeCompleto nomeRazaoSocial, Telefone telefone, CNAE cnae, NomeCompleto nomeContato, AceiteTermosDeUso aceiteTermosDeUso, DateTime dataCadastro) : base(id, celular, cnpj, emailContato, emailFatura, informacoesBancarias, nomeRazaoSocial, telefone, cnae, nomeContato, aceiteTermosDeUso, dataCadastro)
        {
        }
    }
}
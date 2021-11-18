using Jr.Backend.Fornecedores.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.Commands.Response
{
    public class AtualizarFornecedorCommandResponse : Fornecedor
    {
        public AtualizarFornecedorCommandResponse(string celular, string cnpj, IEnumerable<string> emailContato, IEnumerable<string> emailFatura, InformacoesBancarias informacoesBancarias, string nomeRazaoSocial, string telefone, string cnae, string nomeContato, bool aceiteTermosDeUso) : base(celular, cnpj, emailContato, emailFatura, informacoesBancarias, nomeRazaoSocial, telefone, cnae, nomeContato, aceiteTermosDeUso)
        {
        }

        public AtualizarFornecedorCommandResponse(Guid id, string celular, string cnpj, IEnumerable<string> emailContato, IEnumerable<string> emailFatura, InformacoesBancarias informacoesBancarias, string nomeRazaoSocial, string telefone, string cnae, string nomeContato, bool aceiteTermosDeUso, DateTime dataCadastro) : base(id, celular, cnpj, emailContato, emailFatura, informacoesBancarias, nomeRazaoSocial, telefone, cnae, nomeContato, aceiteTermosDeUso, dataCadastro)
        {
        }
    }
}
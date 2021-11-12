using Jr.Backend.Fornecedores.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Jr.Backend.Fornecedores.Domain.Querys.Response
{
    public class ObterFornecedorPorIdResponse : Fornecedor
    {
        [JsonConstructor]
        public ObterFornecedorPorIdResponse(Celular celular, Cnpj cnpj, IEnumerable<EmailContato> emailContato, IEnumerable<EmailFatura> emailFatura, InformacoesBancarias informacoesBancarias, NomeCompleto nomeRazaoSocial, Telefone telefone, CNAE cnae, NomeCompleto nomeContato, AceiteTermosDeUso aceiteTermosDeUso) : base(celular, cnpj, emailContato, emailFatura, informacoesBancarias, nomeRazaoSocial, telefone, cnae, nomeContato, aceiteTermosDeUso)
        {
        }

        public ObterFornecedorPorIdResponse(Guid id, Celular celular, Cnpj cnpj, IEnumerable<EmailContato> emailContato, IEnumerable<EmailFatura> emailFatura, InformacoesBancarias informacoesBancarias, NomeCompleto nomeRazaoSocial, Telefone telefone, CNAE cnae, NomeCompleto nomeContato, AceiteTermosDeUso aceiteTermosDeUso, DateTime dataCadastro) : base(id, celular, cnpj, emailContato, emailFatura, informacoesBancarias, nomeRazaoSocial, telefone, cnae, nomeContato, aceiteTermosDeUso, dataCadastro)
        {
        }
    }
}
using Jr.Backend.Fornecedores.Domain.ValueObjects;
using Jr.Backend.Fornecedores.Domain.ValueObjects.Endereco;
using Jr.Backend.Fornecedores.Domain.ValueObjects.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Jr.Backend.Fornecedores.Domain
{
    public class Fornecedor
    {
        [JsonConstructor]
        public Fornecedor(
            Celular celular,
            Cnpj cnpj,
            IEnumerable<EmailContato> emailContato,
            IEnumerable<EmailFatura> emailFatura,
            InformacoesBancarias informacoesBancarias,
            NomeCompleto nomeRazaoSocial,
            Telefone telefone,
            CNAE cnae,
            NomeCompleto nomeContato,
            AceiteTermosDeUso aceiteTermosDeUso)
        {
            Celular = celular;
            Cnpj = cnpj;
            DataCadastro = DateTime.UtcNow;
            EmailContato = emailContato;
            InformacoesBancarias = informacoesBancarias;
            NomeRazaoSocial = nomeRazaoSocial;
            Telefone = telefone;
            EmailFatura = emailFatura;
            Enderecos = new List<Endereco>();
            Status = StatusCadastro.EmAberto;
            CNAE = cnae;
            NomeContato = nomeContato;
            AceiteTermosDeUso = aceiteTermosDeUso;
            Id = Guid.NewGuid();
        }

        public Fornecedor(
            Celular celular,
            Cnpj cnpj,
            IEnumerable<EmailContato> emailContato,
            IEnumerable<EmailFatura> emailFatura,
            InformacoesBancarias informacoesBancarias,
            NomeCompleto nomeRazaoSocial,
            Telefone telefone,
            CNAE cnae,
            NomeCompleto nomeContato,
            AceiteTermosDeUso aceiteTermosDeUso, DateTime dataCadastro) : this(celular, cnpj, emailContato, emailFatura, informacoesBancarias, nomeRazaoSocial, telefone, cnae, nomeContato, aceiteTermosDeUso)
        {
            DataCadastro = dataCadastro;
        }

        private Guid Id;
        public Celular Celular { get; }

        public CNAE CNAE { get; }
        public Cnpj Cnpj { get; }
        public DateTime DataCadastro { get; }
        public IEnumerable<EmailContato> EmailContato { get; }
        public IEnumerable<EmailFatura> EmailFatura { get; }

        public List<Endereco> Enderecos { get; }
        public InformacoesBancarias InformacoesBancarias { get; }

        public NomeCompleto NomeContato { get; }
        public NomeCompleto NomeRazaoSocial { get; }

        public StatusCadastro Status { get; private set; }

        public Telefone Telefone { get; }

        public AceiteTermosDeUso AceiteTermosDeUso { get; set; }
    }
}
using Jr.Backend.Fornecedores.Domain.Validations;
using Jr.Backend.Fornecedores.Domain.ValueObjects;
using Jr.Backend.Fornecedores.Domain.ValueObjects.Enums;
using Jr.Backend.Libs.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Jr.Backend.Fornecedores.Domain
{
    public class Fornecedor : Entity
    {
        [JsonConstructor]
        public Fornecedor(
            string celular,
            string cnpj,
            IEnumerable<string> emailContato,
            IEnumerable<string> emailFatura,
            InformacoesBancarias informacoesBancarias,
            string nomeRazaoSocial,
            string telefone,
            string cnae,
            string nomeContato,
            bool aceiteTermosDeUso)
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

            Validate(this, new FornecedorValidation());
        }

        public Fornecedor(
            Guid id,
            string celular,
            string cnpj,
            IEnumerable<string> emailContato,
            IEnumerable<string> emailFatura,
            InformacoesBancarias informacoesBancarias,
            string nomeRazaoSocial,
            string telefone,
            string cnae,
            string nomeContato,
            bool aceiteTermosDeUso, DateTime dataCadastro) : this(celular, cnpj, emailContato, emailFatura, informacoesBancarias, nomeRazaoSocial, telefone, cnae, nomeContato, aceiteTermosDeUso)
        {
            Id = id;
            DataCadastro = dataCadastro;
        }

        public string Celular { get; }

        public string CNAE { get; }
        public string Cnpj { get; }
        public DateTime DataCadastro { get; }
        public IEnumerable<string> EmailContato { get; }
        public IEnumerable<string> EmailFatura { get; }

        public List<Endereco> Enderecos { get; }
        public InformacoesBancarias InformacoesBancarias { get; }

        public string NomeContato { get; }
        public string NomeRazaoSocial { get; }

        public StatusCadastro Status { get; private set; }

        public string Telefone { get; }

        public bool AceiteTermosDeUso { get; set; }
    }
}
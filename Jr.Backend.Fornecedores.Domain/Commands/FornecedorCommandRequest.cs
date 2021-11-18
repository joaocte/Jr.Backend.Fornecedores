using System;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.Commands
{
    public class FornecedorCommandRequest
    {
        public string Celular { get; }

        public string CNAE { get; }
        public string Cnpj { get; }
        public DateTime DataCadastro { get; }
        public IEnumerable<string> EmailContato { get; }
        public IEnumerable<string> EmailFatura { get; }

        public List<EnderecoRequest> Enderecos { get; }
        public InformacoesBancariasRequest InformacoesBancarias { get; }

        public string NomeContato { get; }
        public string NomeRazaoSocial { get; }

        public string Telefone { get; }

        public bool AceiteTermosDeUso { get; }

        public FornecedorCommandRequest(string celular, string cnae, string cnpj, DateTime dataCadastro, IEnumerable<string> emailContato, IEnumerable<string> emailFatura, List<EnderecoRequest> enderecos, InformacoesBancariasRequest informacoesBancarias, string nomeContato, string nomeRazaoSocial, string telefone, bool aceiteTermosDeUso)
        {
            Celular = celular;
            CNAE = cnae;
            Cnpj = cnpj;
            DataCadastro = dataCadastro;
            EmailContato = emailContato;
            EmailFatura = emailFatura;
            Enderecos = enderecos;
            InformacoesBancarias = informacoesBancarias;
            NomeContato = nomeContato;
            NomeRazaoSocial = nomeRazaoSocial;
            Telefone = telefone;
            AceiteTermosDeUso = aceiteTermosDeUso;
        }
    }
}
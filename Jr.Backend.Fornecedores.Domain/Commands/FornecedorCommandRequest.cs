using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.Commands
{
    public class FornecedorCommandRequest
    {
        public FornecedorCommandRequest(bool aceiteTermosDeUso, string celular, string cnpj, ICollection<string> emailContato, ICollection<string> emailFatura, InformacoesBancariasRequest informacoesBancarias, string nomeContato)
        {
            AceiteTermosDeUso = aceiteTermosDeUso;
            Celular = celular;
            Cnpj = cnpj;
            EmailContato = emailContato;
            EmailFatura = emailFatura;
            InformacoesBancarias = informacoesBancarias;
            NomeContato = nomeContato;
        }

        public bool AceiteTermosDeUso { get; }
        public string Celular { get; }

        public string Cnpj { get; }
        public ICollection<string> EmailContato { get; }
        public ICollection<string> EmailFatura { get; }

        public InformacoesBancariasRequest InformacoesBancarias { get; }

        public string NomeContato { get; }
    }
}
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.Commands
{
    public class FornecedorCommandRequest
    {
        public FornecedorCommandRequest(string celular, string cnpj, ICollection<string> emailContato, ICollection<string> emailFatura, InformacoesBancariasRequest informacoesBancarias, string nomeContato)
        {
            Celular = celular;
            EmailContato = emailContato;
            EmailFatura = emailFatura;
            InformacoesBancarias = informacoesBancarias;
            NomeContato = nomeContato;
        }

        public string Celular { get; }
        public ICollection<string> EmailContato { get; }
        public ICollection<string> EmailFatura { get; }

        public InformacoesBancariasRequest InformacoesBancarias { get; }

        public string NomeContato { get; }
    }
}
using Jr.Backend.Fornecedores.Domain.Commands.Response;
using MediatR;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.Commands.Request
{
    public class CadastrarFornecedorCommand : FornecedorCommandRequest, IRequest<CadastrarFornecedorCommandResponse>
    {
        public bool AceiteTermosDeUso { get; }
        public string Cnpj { get; }

        public CadastrarFornecedorCommand(string celular, string cnpj, ICollection<string> emailContato, ICollection<string> emailFatura, InformacoesBancariasRequest informacoesBancarias, string nomeContato, bool aceiteTermosDeUso) : base(celular, cnpj, emailContato, emailFatura, informacoesBancarias, nomeContato)
        {
            Cnpj = cnpj;
            AceiteTermosDeUso = aceiteTermosDeUso;
        }
    }
}
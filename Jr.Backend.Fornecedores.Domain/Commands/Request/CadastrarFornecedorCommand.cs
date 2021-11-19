using Jr.Backend.Fornecedores.Domain.Commands.Response;
using MediatR;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.Commands.Request
{
    public class CadastrarFornecedorCommand : FornecedorCommandRequest, IRequest<CadastrarFornecedorCommandResponse>
    {
        public CadastrarFornecedorCommand(bool aceiteTermosDeUso, string celular, string cnpj, IEnumerable<string> emailContato, IEnumerable<string> emailFatura, InformacoesBancariasRequest informacoesBancarias, string nomeContato) : base(aceiteTermosDeUso, celular, cnpj, emailContato, emailFatura, informacoesBancarias, nomeContato)
        {
        }
    }
}
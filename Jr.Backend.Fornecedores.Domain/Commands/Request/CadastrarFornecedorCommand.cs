using Jr.Backend.Fornecedores.Domain.Commands.Reqiest;
using Jr.Backend.Fornecedores.Domain.ValueObjects;
using MediatR;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.Commands.Request
{
    public class CadastrarFornecedorCommand : Fornecedor, IRequest<CadastrarFornecedorCommandResponse>
    {
        public CadastrarFornecedorCommand(Celular celular, Cnpj cnpj, IEnumerable<EmailContato> emailContato, IEnumerable<EmailFatura> emailFatura, InformacoesBancarias informacoesBancarias, NomeCompleto nomeRazaoSocial, Telefone telefone, CNAE cnae, NomeCompleto nomeContato, AceiteTermosDeUso aceiteTermosDeUso) : base(celular, cnpj, emailContato, emailFatura, informacoesBancarias, nomeRazaoSocial, telefone, cnae, nomeContato, aceiteTermosDeUso)
        {
        }
    }
}
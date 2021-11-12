using Jr.Backend.Fornecedores.Domain.Commands.Response;
using Jr.Backend.Fornecedores.Domain.ValueObjects;
using Jr.Backend.Fornecedores.Domain.ValueObjects.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jr.Backend.Fornecedores.Domain.Commands.Request
{
    public class CadastrarFornecedorCommand : FornecedorCommandRequest, IRequest<CadastrarFornecedorCommandResponse>
    {
        public CadastrarFornecedorCommand(string celular, string cnae, string cnpj, DateTime dataCadastro, IEnumerable<string> emailContato, IEnumerable<string> emailFatura, List<EnderecoRequest> enderecos, InformacoesBancariasRequest informacoesBancarias, string nomeContato, string nomeRazaoSocial, StatusCadastro status, string telefone, bool aceiteTermosDeUso) : base(celular, cnae, cnpj, dataCadastro, emailContato, emailFatura, enderecos, informacoesBancarias, nomeContato, nomeRazaoSocial, status, telefone, aceiteTermosDeUso)
        {
        }

        public Fornecedor Convert()
        {
            return new Fornecedor(this.Celular, this.Cnpj, this.EmailContato.Select(x => new EmailContato(x)),
                this.EmailContato.Select(x => new EmailFatura(x)),
                new InformacoesBancarias(this.InformacoesBancarias.Banco, this.InformacoesBancarias.Agencia,
                    this.InformacoesBancarias.Conta, this.InformacoesBancarias.TipoConta), this.NomeRazaoSocial,
                this.Telefone, this.CNAE, this.NomeContato, this.AceiteTermosDeUso);
        }
    }
}
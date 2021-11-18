using Jr.Backend.Fornecedores.Domain.Commands.Response;
using Jr.Backend.Fornecedores.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.Commands.Request
{
    public class CadastrarFornecedorCommand : FornecedorCommandRequest, IRequest<CadastrarFornecedorCommandResponse>
    {
        public Fornecedor Convert()
        {
            return new Fornecedor(Celular, Cnpj, EmailContato,
                EmailFatura,
                new InformacoesBancarias(InformacoesBancarias.Banco, InformacoesBancarias.Agencia,
                    InformacoesBancarias.Conta, InformacoesBancarias.TipoConta), NomeRazaoSocial,
                Telefone, CNAE, NomeContato, AceiteTermosDeUso);
        }

        public CadastrarFornecedorCommand(string celular, string cnae, string cnpj, DateTime dataCadastro, IEnumerable<string> emailContato, IEnumerable<string> emailFatura, List<EnderecoRequest> enderecos, InformacoesBancariasRequest informacoesBancarias, string nomeContato, string nomeRazaoSocial, string telefone, bool aceiteTermosDeUso) : base(celular, cnae, cnpj, dataCadastro, emailContato, emailFatura, enderecos, informacoesBancarias, nomeContato, nomeRazaoSocial, telefone, aceiteTermosDeUso)
        {
        }
    }
}
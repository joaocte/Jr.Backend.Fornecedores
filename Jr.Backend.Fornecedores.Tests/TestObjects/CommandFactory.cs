using Jr.Backend.Fornecedores.Domain.Commands;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using System;
using System.Linq;

namespace Jr.Backend.Fornecedores.Tests.TestObjects
{
    public static class CommandFactory
    {
        public static CadastrarFornecedorCommand GerarCadastrarFornecedorCommandValido()
        {
            var fornecedor = FornecedorFactory.DeveInstanciarUmNovoFornecedorValido();
            var enderecos = fornecedor.Enderecos.Select(x =>
                new EnderecoRequest(x.Bairro, x.Cep, x.Cidade, x.Complemento, x.Estado, x.Logradouro,
                    x.Numero)).ToList();
            return new CadastrarFornecedorCommand(fornecedor.Celular,
                fornecedor.CNAE,
                fornecedor.Cnpj,
                fornecedor.DataCadastro,
                fornecedor.EmailContato.Select(x => x.ToString()),
                fornecedor.EmailFatura.Select(x => x.ToString()),
                enderecos,
                new InformacoesBancariasRequest(fornecedor.InformacoesBancarias.Agencia, fornecedor.InformacoesBancarias.Banco, fornecedor.InformacoesBancarias.Conta, fornecedor.InformacoesBancarias.TipoConta),
                fornecedor.NomeContato,
                fornecedor.NomeRazaoSocial,
                fornecedor.Status,
                fornecedor.Telefone,
                fornecedor.AceiteTermosDeUso);
        }

        public static CadastrarFornecedorCommand GerarCadastrarFornecedorCommandInValido()
        {
            var fornecedor = FornecedorFactory.DeveInstanciarUmNovoFornecedorInValido();
            var enderecos = fornecedor.Enderecos.Select(x =>
                new EnderecoRequest(x.Bairro, x.Cep, x.Cidade, x.Complemento, x.Estado, x.Logradouro,
                    x.Numero)).ToList();
            return new CadastrarFornecedorCommand(fornecedor.Celular,
                fornecedor.CNAE,
                fornecedor.Cnpj,
                fornecedor.DataCadastro,
                fornecedor.EmailContato.Select(x => x.ToString()),
                fornecedor.EmailFatura.Select(x => x.ToString()),
                enderecos,
                new InformacoesBancariasRequest(fornecedor.InformacoesBancarias.Agencia, fornecedor.InformacoesBancarias.Banco, fornecedor.InformacoesBancarias.Conta, fornecedor.InformacoesBancarias.TipoConta),
                fornecedor.NomeContato,
                fornecedor.NomeRazaoSocial,
                fornecedor.Status,
                fornecedor.Telefone,
                fornecedor.AceiteTermosDeUso);
        }

        public static AtualizarFornecedorCommand GerarAtualizarFornecedorCommandValido(Guid id, DateTime dataCadastro)
        {
            var fornecedor = FornecedorFactory.DeveInstanciarUmNovoFornecedorValido();
            var enderecos = fornecedor.Enderecos.Select(x =>
                new EnderecoRequest(x.Bairro, x.Cep, x.Cidade, x.Complemento, x.Estado, x.Logradouro,
                    x.Numero)).ToList();
            return new AtualizarFornecedorCommand(
                fornecedor.Celular,
                fornecedor.CNAE,
                fornecedor.Cnpj,
                dataCadastro,
                fornecedor.EmailContato.Select(x => x.ToString()),
                fornecedor.EmailFatura.Select(x => x.ToString()),
                enderecos,
                new InformacoesBancariasRequest(fornecedor.InformacoesBancarias.Agencia, fornecedor.InformacoesBancarias.Banco, fornecedor.InformacoesBancarias.Conta, fornecedor.InformacoesBancarias.TipoConta),
                fornecedor.NomeContato,
                fornecedor.NomeRazaoSocial,
                fornecedor.Status,
                fornecedor.Telefone,
                fornecedor.AceiteTermosDeUso,
                id);
        }
    }
}
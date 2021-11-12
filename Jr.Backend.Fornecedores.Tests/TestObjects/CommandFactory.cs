using Jr.Backend.Fornecedores.Domain.Commands.Request;
using System;

namespace Jr.Backend.Fornecedores.Tests.TestObjects
{
    public static class CommandFactory
    {
        public static CadastrarFornecedorCommand GerarCadastrarFornecedorCommandValido()
        {
            var fornecedor = FornecedorFactory.DeveInstanciarUmNovoFornecedorValido();

            return new CadastrarFornecedorCommand(fornecedor.Celular, fornecedor.Cnpj, fornecedor.EmailContato,
                fornecedor.EmailFatura, fornecedor.InformacoesBancarias, fornecedor.NomeRazaoSocial,
                fornecedor.Telefone, fornecedor.CNAE, fornecedor.NomeContato, fornecedor.AceiteTermosDeUso);
        }

        public static CadastrarFornecedorCommand GerarCadastrarFornecedorCommandInValido()
        {
            var fornecedor = FornecedorFactory.DeveInstanciarUmNovoFornecedorInValido();

            return new CadastrarFornecedorCommand(fornecedor.Celular, fornecedor.Cnpj, fornecedor.EmailContato,
                fornecedor.EmailFatura, fornecedor.InformacoesBancarias, fornecedor.NomeRazaoSocial,
                fornecedor.Telefone, fornecedor.CNAE, fornecedor.NomeContato, fornecedor.AceiteTermosDeUso);
        }

        public static AtualizarFornecedorCommand GerarAtualizarFornecedorCommandValido(Guid id, DateTime dataCadastro)
        {
            var fornecedor = FornecedorFactory.DeveInstanciarUmNovoFornecedorValido();
            return new AtualizarFornecedorCommand(id, fornecedor.Celular, fornecedor.Cnpj, fornecedor.EmailContato,
                fornecedor.EmailFatura, fornecedor.InformacoesBancarias, fornecedor.NomeRazaoSocial,
                fornecedor.Telefone, fornecedor.CNAE, fornecedor.NomeContato, fornecedor.AceiteTermosDeUso, dataCadastro);
        }
    }
}
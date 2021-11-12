using Jr.Backend.Fornecedores.Domain.ValueObjects;
using Jr.Backend.Fornecedores.Domain.ValueObjects.Enums;
using System;

namespace Jr.Backend.Fornecedores.Tests.TestObjects
{
    public static class FornecedorFactory
    {
        public static Fornecedores.Domain.Fornecedor DeveInstanciarUmNovoFornecedorValido()
        {
            return new Fornecedores.Domain.Fornecedor("celular", "05570796000131", EmailFactory.DeveInstanciarUmaListaEmailContato(),
                EmailFactory.DeveInstanciarUmaListaEmailFatura(),
                new InformacoesBancarias("banco", "agencia", "conta", TipoConta.ContaCorrente), "RazaoSocial",
                "Telefone", "CNAE", "NomeContato", true);
        }

        public static Fornecedores.Domain.Fornecedor DeveInstanciarUmNovoFornecedorInValido()
        {
            return new Fornecedores.Domain.Fornecedor("", "", EmailFactory.DeveInstanciarUmaListaEmailContato(),
                EmailFactory.DeveInstanciarUmaListaEmailFatura(),
                new InformacoesBancarias("", "", "", TipoConta.ContaCorrente), "",
                "", "", "", false);
        }

        public static Fornecedores.Domain.Fornecedor DeveInstanciarUmFornecedorJaCadastrado(Guid id, DateTime dataCadastro)
        {
            return new Fornecedores.Domain.Fornecedor(id, "celular", "05570796000131", EmailFactory.DeveInstanciarUmaListaEmailContato(),
                EmailFactory.DeveInstanciarUmaListaEmailFatura(),
                new InformacoesBancarias("banco", "agencia", "conta", TipoConta.ContaCorrente), "RazaoSocial",
                "Telefone", "CNAE", "NomeContato", true, dataCadastro);
        }
    }
}
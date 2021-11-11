using Jr.Backend.Fornecedores.Domain;
using Jr.Backend.Fornecedores.Domain.ValueObjects;
using Jr.Backend.Fornecedores.Domain.ValueObjects.Enums;
using System;

namespace Jr.Backend.Fornecedores.Tests.TestObjects
{
    public static class FornecedorFactory
    {
        public static Fornecedor DeveInstanciarUmNovoFornecedorValido()
        {
            return new Fornecedor("celular", "05570796000131", EmailFactory.DeveInstanciarUmaListaEmailContato(),
                EmailFactory.DeveInstanciarUmaListaEmailFatura(),
                new InformacoesBancarias("banco", "agencia", "conta", TipoConta.ContaCorrente), "RazaoSocial",
                "Telefone", "CNAE", "NomeContato", true);
        }

        public static Fornecedor DeveInstanciarUmNovoFornecedorInValido()
        {
            return new Fornecedor("", "", EmailFactory.DeveInstanciarUmaListaEmailContato(),
                EmailFactory.DeveInstanciarUmaListaEmailFatura(),
                new InformacoesBancarias("", "", "", TipoConta.ContaCorrente), "",
                "", "", "", false);
        }

        public static Fornecedor DeveInstanciarUmFornecedorJaCadastrado(Guid id, DateTime dataCadastro)
        {
            return new Fornecedor(id, "celular", "05570796000131", EmailFactory.DeveInstanciarUmaListaEmailContato(),
                EmailFactory.DeveInstanciarUmaListaEmailFatura(),
                new InformacoesBancarias("banco", "agencia", "conta", TipoConta.ContaCorrente), "RazaoSocial",
                "Telefone", "CNAE", "NomeContato", true, dataCadastro);
        }
    }
}
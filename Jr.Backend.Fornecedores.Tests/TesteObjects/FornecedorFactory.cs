using Bogus;
using Jr.Backend.Fornecedores.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Tests.TesteObjects
{
    public static class FornecedorFactory
    {
        public static Fornecedores.Domain.Fornecedor DeveInstanciarUmFornecedorValido()
        {
            List<CnaesSecundario> cnaesSecundarios = new Faker<CnaesSecundario>().Generate(2);
            List<String> emailList = new List<string>()
            {
                "email@teste.com.br",
                "email2@teste.com.br"
            };

            List<Endereco> enderecos = new Faker<Endereco>().Generate(2);
            InformacoesBancarias informacoesBancarias = new Faker<InformacoesBancarias>().Generate();
            List<Qsa> qsas = new Faker<Qsa>().Generate(2);
            List<String> telefones = new List<string>()
            {
                "123212355215415",
                "121545124151231"
            };
            return new Faker<Fornecedores.Domain.Fornecedor>().CustomInstantiator(f => new Fornecedores.Domain.Fornecedor(true, 10, "celular", 1, "cnaeDescricao", cnaesSecundarios, "33597465000120", 0, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, "descricao matriz", "descricao Porte", "descricao Situacao Cadastral", emailList, emailList, enderecos, 1, informacoesBancarias, 1, "nomeCidadeEsteror", "nomeContato", "nomeFantasia", true, true, 10, qsas, 1, "razaoSocial", 1, "situacaoespecial", telefones));
        }

        public static Fornecedores.Domain.Fornecedor DeveInstanciarUmFornecedorValido(Guid id, DateTime datacadastro)
        {
            List<CnaesSecundario> cnaesSecundarios = new Faker<CnaesSecundario>().Generate(2);
            List<String> emailList = new List<string>()
            {
                "email@teste.com.br",
                "email2@teste.com.br"
            };

            List<Endereco> enderecos = new Faker<Endereco>().Generate(2);
            InformacoesBancarias informacoesBancarias = new Faker<InformacoesBancarias>().Generate();
            List<Qsa> qsas = new Faker<Qsa>().Generate(2);
            List<String> telefones = new List<string>()
            {
                "123212355215415",
                "121545124151231"
            };
            return new Faker<Fornecedores.Domain.Fornecedor>().CustomInstantiator(f => new Fornecedores.Domain.Fornecedor(id, true, 10, "celular", 1, "cnaeDescricao", cnaesSecundarios, "33597465000120", 0, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, "descricao matriz", "descricao Porte", "descricao Situacao Cadastral", emailList, emailList, enderecos, 1, informacoesBancarias, 1, "nomeCidadeEsteror", "nomeContato", "nomeFantasia", true, true, 10, qsas, 1, "razaoSocial", 1, "situacaoespecial", telefones));
        }
    }
}
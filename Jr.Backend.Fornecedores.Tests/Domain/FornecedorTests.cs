using Jr.Backend.Fornecedores.Domain.Validations;
using Jr.Backend.Fornecedores.Tests.TestObjects;
using System;
using Xunit;

namespace Jr.Backend.Fornecedores.Tests.Domain
{
    public class FornecedorTests
    {
        [Fact]
        public void DeveInstanciarUmFornecedorValido()
        {
            var fornecedor = FornecedorFactory.DeveInstanciarUmNovoFornecedorValido();

            fornecedor.Validate(fornecedor, new FornecedorValidation());

            Assert.True(fornecedor.Valid);
        }

        [Fact]
        public void DeveCarregarUmFornecedorJaCadastrado()
        {
            var id = Guid.NewGuid();
            var dataCadastro = DateTime.Now.AddDays(-2);
            var fornecedor = FornecedorFactory.DeveInstanciarUmFornecedorJaCadastrado(id, dataCadastro);

            fornecedor.Validate(fornecedor, new FornecedorValidation());

            Assert.True(fornecedor.Valid);
            Assert.Equal(id, fornecedor.Id);
            Assert.Equal(dataCadastro, fornecedor.DataCadastro);
        }
    }
}
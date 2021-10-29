using Jr.Backend.Libs.Domain.Abstractions.ValueObject;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    /// <inheritdoc/>
    public class Cnpj : GenericValueObject
    {
        private readonly string cpfCnpj;

        private Cnpj(string cpfCnpj)
        {
            this.cpfCnpj = cpfCnpj;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return cpfCnpj;
        }

        /// <inheritdoc/>
        public static implicit operator Cnpj(string cpfCnpj) => new(cpfCnpj);

        /// <inheritdoc/>
        public static implicit operator string(Cnpj cpfCnpj) => cpfCnpj;
    }
}
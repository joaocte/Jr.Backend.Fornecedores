using Jr.Backend.Libs.Domain.Abstractions.ValueObject;

using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    /// <inheritdoc/>
    public class Telefone : GenericValueObject
    {
        private readonly string telefone;

        private Telefone(string telefone)
        {
            this.telefone = telefone;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return telefone;
        }

        /// <inheritdoc/>
        public static implicit operator Telefone(string telefone) => new(telefone);

        /// <inheritdoc/>
        public static implicit operator string(Telefone telefone) => telefone.telefone;
    }
}
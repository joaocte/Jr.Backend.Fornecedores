using Jr.Backend.Libs.Domain.Abstractions.ValueObject;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    public class Complemento : GenericValueObject
    {
        private readonly string complemento;

        public Complemento(string complemento)
        {
            this.complemento = complemento;
        }

        /// <inheritdoc/>
        public static implicit operator Complemento(string complemento) => new(complemento);

        /// <inheritdoc/>
        public static implicit operator string(Complemento complemento) => complemento;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return complemento;
        }
    }
}
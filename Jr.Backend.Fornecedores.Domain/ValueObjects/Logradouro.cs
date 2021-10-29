using Jr.Backend.Libs.Domain.Abstractions.ValueObject;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    public class Logradouro : GenericValueObject
    {
        private readonly string logradouro;

        public Logradouro(string logradouro)
        {
            this.logradouro = logradouro;
        }

        /// <inheritdoc/>
        public static implicit operator Logradouro(string logradouro) => new(logradouro);

        /// <inheritdoc/>
        public static implicit operator string(Logradouro logradouro) => logradouro;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return logradouro;
        }
    }
}
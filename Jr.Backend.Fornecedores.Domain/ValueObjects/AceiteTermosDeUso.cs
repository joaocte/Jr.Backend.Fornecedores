using Jr.Backend.Libs.Domain.Abstractions.ValueObject;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    public class AceiteTermosDeUso : GenericValueObject
    {
        private readonly bool aceiteTermo;

        private AceiteTermosDeUso(bool aceiteTermosUso)
        {
            aceiteTermo = aceiteTermosUso;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return aceiteTermo;
        }

        /// <inheritdoc/>
        public static implicit operator AceiteTermosDeUso(bool aceiteTermo) => new(aceiteTermo);

        /// <inheritdoc/>
        public static implicit operator bool(AceiteTermosDeUso aceiteTermo) => aceiteTermo.aceiteTermo;
    }
}
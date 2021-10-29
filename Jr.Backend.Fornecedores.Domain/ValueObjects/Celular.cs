using Jr.Backend.Libs.Domain.Abstractions.ValueObject;

using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    /// <inheritdoc/>
    public class Celular : GenericValueObject
    {
        private readonly string celular;

        private Celular(string celular)
        {
            this.celular = celular;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return celular;
        }

        public static implicit operator Celular(string celular) => new(celular);

        public static implicit operator string(Celular celular) => celular.celular;
    }
}
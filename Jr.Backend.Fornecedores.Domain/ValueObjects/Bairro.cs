using Jr.Backend.Libs.Domain.Abstractions.ValueObject;

using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    public class Bairro : GenericValueObject
    {
        private readonly string bairro;

        /// <inheritdoc/>
        public Bairro(string bairro)
        {
            this.bairro = bairro;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return bairro;
        }

        public static implicit operator Bairro(string bairro) => new(bairro);

        public static implicit operator string(Bairro bairro) => bairro;
    }
}
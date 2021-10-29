using Jr.Backend.Libs.Domain.Abstractions.ValueObject;

using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    public class Numero : GenericValueObject
    {
        private readonly string numero;

        public Numero(string numero)
        {
            this.numero = numero;
        }

        /// <inheritdoc/>
        public static implicit operator Numero(string numero) => new(numero);

        /// <inheritdoc/>
        public static implicit operator string(Numero numero) => numero;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return numero;
        }
    }
}
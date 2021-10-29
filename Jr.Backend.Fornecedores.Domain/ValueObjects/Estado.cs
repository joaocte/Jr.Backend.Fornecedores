using Jr.Backend.Libs.Domain.Abstractions.ValueObject;

using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    public class Estado : GenericValueObject
    {
        private readonly string estado;

        public Estado(string estado)
        {
            this.estado = estado;
        }

        /// <inheritdoc/>

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return estado;
        }

        /// <inheritdoc/>
        public static implicit operator Estado(string estado) => new(estado);

        /// <inheritdoc/>
        public static implicit operator string(Estado estado) => estado;
    }
}
using Jr.Backend.Libs.Domain.Abstractions.ValueObject;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    /// <inheritdoc/>
    public class CNAE : GenericValueObject
    {
        private readonly string cnae;

        private CNAE(string cnae)
        {
            this.cnae = cnae;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return cnae;
        }

        /// <inheritdoc/>
        public static implicit operator CNAE(string cnae) => new(cnae);

        /// <inheritdoc/>
        public static implicit operator string(CNAE cnae) => cnae;
    }
}
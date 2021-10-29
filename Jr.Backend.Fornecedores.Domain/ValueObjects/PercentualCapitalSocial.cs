using Jr.Backend.Libs.Domain.Abstractions.ValueObject;

using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    public class PercentualCapitalSocial : GenericValueObject
    {
        private readonly decimal percentualCapitalSocial;

        public PercentualCapitalSocial(decimal percentualCapitalSocial)
        {
            this.percentualCapitalSocial = percentualCapitalSocial;
        }

        /// <inheritdoc/>
        public static implicit operator PercentualCapitalSocial(decimal percentualCapitalSocial) => new(percentualCapitalSocial);

        /// <inheritdoc/>
        public static implicit operator decimal(PercentualCapitalSocial percentualCapitalSocial) => percentualCapitalSocial;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return percentualCapitalSocial;
        }
    }
}
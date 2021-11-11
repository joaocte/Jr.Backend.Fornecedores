using Jr.Backend.Libs.Domain.Abstractions.ValueObject;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    /// <inheritdoc/>
    public abstract class Email : GenericValueObject
    {
        private readonly string email;

        protected Email(string email)
        {
            this.email = email;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return email;
        }

        public override string ToString()
        {
            return email;
        }

        /// <inheritdoc/>
        public static implicit operator string(Email email) => email.email;
    }
}
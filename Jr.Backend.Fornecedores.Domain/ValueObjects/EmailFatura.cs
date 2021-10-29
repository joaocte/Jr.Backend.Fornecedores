using Jr.Backend.Libs.Domain.Abstractions.ValueObject;

using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    /// <inheritdoc/>
    public class EmailFatura : GenericValueObject
    {
        private readonly string email;

        private EmailFatura(string email)
        {
            this.email = email;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return email;
        }

        /// <inheritdoc/>
        public static implicit operator EmailFatura(string email) => new(email);

        /// <inheritdoc/>
        public static implicit operator string(EmailFatura email) => email.email;
    }
}
using Jr.Backend.Libs.Domain.Abstractions.ValueObject;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    /// <inheritdoc/>
    public class EmailContato : GenericValueObject
    {
        private readonly string email;

        private EmailContato(string email)
        {
            this.email = email;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return email;
        }

        /// <inheritdoc/>
        public static implicit operator EmailContato(string email) => new(email);

        /// <inheritdoc/>
        public static implicit operator string(EmailContato email) => email.email;
    }
}
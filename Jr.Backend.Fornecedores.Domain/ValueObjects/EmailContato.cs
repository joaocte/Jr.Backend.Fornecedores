namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    /// <inheritdoc/>
    public class EmailContato : Email
    {
        public EmailContato(string email) : base(email)
        {
        }

        /// <inheritdoc/>
        public static implicit operator EmailContato(string email) => new(email);
    }
}
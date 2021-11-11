namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    /// <inheritdoc/>
    public class EmailFatura : Email
    {
        public EmailFatura(string email) : base(email)
        {
        }

        /// <inheritdoc/>
        public static implicit operator EmailFatura(string email) => new(email);
    }
}
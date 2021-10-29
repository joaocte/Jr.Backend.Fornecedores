namespace Jr.Backend.Fornecedores.Domain.ValueObjects.Endereco
{
    /// <summary>
    /// View Object Endereco
    /// </summary>
    public abstract class Endereco
    {
        /// <inheritdoc/>
        public Endereco(Cep cep, Logradouro logradouro,
            Numero numero,
            Complemento complemento,
            Bairro bairro,
            Cidade cidade,
            Estado estado)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        /// <summary>
        /// <see cref="Bairro"/>
        /// </summary>
        public Bairro Bairro { get; private set; }

        /// <summary>
        /// <see cref="Cep"/>
        /// </summary>
        public Cep Cep { get; private set; }

        /// <summary>
        /// <see cref="Cidade"/>
        /// </summary>
        public Cidade Cidade { get; private set; }

        /// <summary>
        /// <see cref="Complemento"/>
        /// </summary>
        public Complemento Complemento { get; private set; }

        /// <summary>
        /// <see cref="Estado"/>
        /// </summary>
        public Estado Estado { get; private set; }

        /// <summary>
        /// <see cref="Logradouro"/>
        /// </summary>
        public Logradouro Logradouro { get; private set; }

        /// <summary>
        /// <see cref="Numero"/>
        /// </summary>
        public Numero Numero { get; private set; }
    }
}
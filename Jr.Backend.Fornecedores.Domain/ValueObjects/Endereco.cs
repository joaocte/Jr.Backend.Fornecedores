namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    /// <summary>
    /// View Object Endereco
    /// </summary>
    public class Endereco
    {
        public Endereco(string bairro, string cep, string cidade, string complemento, string estado, string logradouro, string numero)
        {
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Complemento = complemento;
            Estado = estado;
            Logradouro = logradouro;
            Numero = numero;
        }

        /// <summary>
        /// <see cref="Bairro"/>
        /// </summary>
        public string Bairro { get; private set; }

        /// <summary>
        /// <see cref="Cep"/>
        /// </summary>
        public string Cep { get; private set; }

        /// <summary>
        /// <see cref="Cidade"/>
        /// </summary>
        public string Cidade { get; private set; }

        /// <summary>
        /// <see cref="Complemento"/>
        /// </summary>
        public string Complemento { get; private set; }

        /// <summary>
        /// <see cref="Estado"/>
        /// </summary>
        public string Estado { get; private set; }

        /// <summary>
        /// <see cref="Logradouro"/>
        /// </summary>
        public string Logradouro { get; private set; }

        /// <summary>
        /// <see cref="Numero"/>
        /// </summary>
        public string Numero { get; private set; }
    }
}
using Jror.Backend.Libs.Domain.Abstractions.ValueObject;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    /// <summary>
    /// View Object Endereco
    /// </summary>
    public class Endereco : ValueObject
    {
        [JsonConstructor]
        public Endereco(string bairro, string cep, string cidade, string complemento, string descricaoTipoLogradouro, string uf, string logradouro, string numero, int codigoMunicipio)
        {
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Complemento = complemento;
            DescricaoTipoLogradouro = descricaoTipoLogradouro;
            Uf = uf;
            Logradouro = logradouro;
            Numero = numero;
            CodigoMunicipio = codigoMunicipio;
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

        public int CodigoMunicipio { get; private set; }

        /// <summary>
        /// <see cref="Complemento"/>
        /// </summary>
        public string Complemento { get; private set; }

        public string DescricaoTipoLogradouro { get; private set; }

        /// <summary>
        /// <see cref="Uf"/>
        /// </summary>
        public string Uf { get; private set; }

        /// <summary>
        /// <see cref="Logradouro"/>
        /// </summary>
        public string Logradouro { get; private set; }

        /// <summary>
        /// <see cref="Numero"/>
        /// </summary>
        public string Numero { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Bairro;
            yield return Cidade;
            yield return Cep;
            yield return CodigoMunicipio;
            yield return Complemento;
            yield return DescricaoTipoLogradouro;
            yield return Uf;
            yield return Logradouro;
            yield return Numero;
        }
    }
}
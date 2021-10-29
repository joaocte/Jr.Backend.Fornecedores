using Jr.Backend.Libs.Domain.Abstractions.ValueObject;

using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    public class Agencia : GenericValueObject
    {
        private readonly string agencia;

        private Agencia(string agencia)
        {
            this.agencia = agencia;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return agencia;
        }

        /// <summary>
        /// Converte string para <see cref="Agencia"/>.
        /// </summary>
        /// <param name="agencia">string</param>
        /// <returns><see cref="Agencia"/></returns>
        public static implicit operator Agencia(string agencia) => new(agencia);

        /// <summary>
        /// Converte <see cref="Agencia"/> para string.
        /// </summary>
        /// <param name="agencia"><see cref="Agencia"/></param>
        /// <returns>string.</returns>
        public static implicit operator string(Agencia agencia) => agencia.agencia;
    }
}
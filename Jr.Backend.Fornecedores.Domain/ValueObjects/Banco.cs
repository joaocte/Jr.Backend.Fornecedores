using Jr.Backend.Libs.Domain.Abstractions.ValueObject;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    public class Banco : GenericValueObject
    {
        private readonly string banco;

        private Banco(string banco)
        {
            this.banco = banco;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return banco;
        }

        /// <summary>
        /// Converte string para <see cref="Banco"/>.
        /// </summary>
        /// <param name="banco">string</param>
        /// <returns><see cref="Banco"/></returns>
        public static implicit operator Banco(string banco) => new(banco);

        /// <summary>
        /// Converte <see cref="Banco"/> para string.
        /// </summary>
        /// <param name="banco"><see cref="Banco"/></param>
        /// <returns>string.</returns>
        public static implicit operator string(Banco banco) => banco;
    }
}
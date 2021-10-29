using Jr.Backend.Libs.Domain.Abstractions.ValueObject;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    public class Cargo : GenericValueObject
    {
        private readonly string cargo;

        public Cargo(string cargo)
        {
            this.cargo = cargo;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return cargo;
        }

        /// <summary>
        /// Converte string para <see cref="Banco"/>.
        /// </summary>
        /// <param name="banco">string</param>
        /// <returns><see cref="Banco"/></returns>
        public static implicit operator Cargo(string cargo) => new(cargo);

        /// <summary>
        /// Converte <see cref="Banco"/> para string.
        /// </summary>
        /// <param name="banco"><see cref="Banco"/></param>
        /// <returns>string.</returns>
        public static implicit operator string(Cargo cargo) => cargo;
    }
}
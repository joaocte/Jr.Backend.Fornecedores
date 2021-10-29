using Jr.Backend.Libs.Domain.Abstractions.ValueObject;

using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    public class NomeCompleto : GenericValueObject
    {
        private readonly string nomeColaborador;

        public NomeCompleto(string nomeColaborador)
        {
            this.nomeColaborador = nomeColaborador;
        }

        /// <inheritdoc/>
        public static implicit operator NomeCompleto(string nomeColaborador) => new(nomeColaborador);

        /// <inheritdoc/>
        public static implicit operator string(NomeCompleto nomeColaborador) => nomeColaborador;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return nomeColaborador;
        }
    }
}
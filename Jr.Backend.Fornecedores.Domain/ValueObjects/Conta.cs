using Jr.Backend.Libs.Domain.Abstractions.ValueObject;

using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    public class Conta : GenericValueObject
    {
        private readonly string contaCorrente;

        private Conta(string contaCorrente)
        {
            this.contaCorrente = contaCorrente;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return contaCorrente;
        }

        public static implicit operator Conta(string contaCorrente) => new(contaCorrente);

        public static implicit operator string(Conta contaCorrente) => contaCorrente.contaCorrente;
    }
}
using Jr.Backend.Libs.Domain.Abstractions.ValueObject;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    public class Cep : GenericValueObject
    {
        private readonly string cep;

        public Cep(string cep)
        {
            this.cep = cep;
        }

        public static implicit operator Cep(string cep) => new(cep);

        public static implicit operator string(Cep cep) => cep;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return cep;
        }
    }
}
using Jr.Backend.Libs.Domain.Abstractions.ValueObject;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    public class Cidade : GenericValueObject
    {
        private readonly string cidade;

        public Cidade(string cidade)
        {
            this.cidade = cidade;
        }

        public static implicit operator Cidade(string cidade) => new(cidade);

        public static implicit operator string(Cidade cidade) => cidade;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return cidade;
        }
    }
}
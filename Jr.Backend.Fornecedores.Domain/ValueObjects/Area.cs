using Jr.Backend.Libs.Domain.Abstractions.ValueObject;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    public class Area : GenericValueObject
    {
        private readonly string area;

        public Area(string area)
        {
            this.area = area;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return area;
        }

        public static implicit operator Area(string area) => new(area);

        public static implicit operator string(Area area) => area;
    }
}
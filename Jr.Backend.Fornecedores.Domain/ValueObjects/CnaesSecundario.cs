using Jror.Backend.Libs.Domain.Abstractions.ValueObject;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    public class CnaesSecundario : ValueObject
    {
        [JsonConstructor]
        public CnaesSecundario(int codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }

        protected CnaesSecundario()
        {
        }

        public int Codigo { get; private set; }

        public string Descricao { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Codigo;
            yield return Descricao;
        }
    }
}
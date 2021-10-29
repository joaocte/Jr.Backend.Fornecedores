using Jr.Backend.Fornecedores.Domain.ValueObjects.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Jr.Backend.Fornecedores.Infrastructure.Entity.Comum
{
    public class InformacoesBancarias
    {
        public string Agencia { get; set; }
        public string Banco { get; set; }
        public string Conta { get; set; }

        [BsonRepresentation(BsonType.String)]
        public TipoConta TipoConta { get; set; }
    }
}
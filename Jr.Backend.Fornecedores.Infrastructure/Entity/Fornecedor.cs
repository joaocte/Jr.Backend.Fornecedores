using Jr.Backend.Fornecedores.Domain.ValueObjects.Enums;
using Jr.Backend.Fornecedores.Infrastructure.Entity.Comum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Infrastructure.Entity
{
    public class Fornecedor
    {
        public string Celular { get; set; }

        public string CNAE { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataCadastro { get; set; }
        public IEnumerable<string> EmailContato { get; set; }
        public IEnumerable<string> EmailFatura { get; set; }

        public List<string> Enderecos { get; set; }
        public InformacoesBancarias InformacoesBancarias { get; set; }

        public string NomeContato { get; set; }
        public string NomeRazaoSocial { get; set; }

        [BsonRepresentation(BsonType.String)]
        public StatusCadastro Status { get; private set; }

        public string Telefone { get; set; }

        public bool AceiteTermosDeUso { get; set; }
    }
}
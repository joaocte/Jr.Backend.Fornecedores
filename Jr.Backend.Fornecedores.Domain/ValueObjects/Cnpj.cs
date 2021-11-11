﻿using Jr.Backend.Libs.Domain.Abstractions.ValueObject;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Domain.ValueObjects
{
    /// <inheritdoc/>
    public class Cnpj : GenericValueObject
    {
        private readonly string cnpj;

        private Cnpj(string cnpj)
        {
            this.cnpj = cnpj;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return cnpj;
        }

        public override string ToString()
        {
            return cnpj;
        }

        /// <inheritdoc/>
        public static implicit operator Cnpj(string cpfCnpj) => new(cpfCnpj);

        /// <inheritdoc/>
        public static implicit operator string(Cnpj cpfCnpj) => cpfCnpj;
    }
}
using FluentValidation;
using Jr.Backend.Fornecedores.Domain.ValueObjects;
using Jr.Backend.Libs.Domain.Core.Validations;

namespace Jr.Backend.Fornecedores.Domain.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(p => p.Celular).NotEmpty()
                .NotNull()
                .WithMessage("Celular deve ser informado");

            RuleFor(p => p.Cnpj.ToString())
                .NotNull()
                .NotEmpty()
                .CnpjValido()
                .WithMessage("Cnpj deve ser informado ou é Inválido");

            RuleFor(p => p.CNAE)
                .NotNull()
                .NotEmpty()
                .WithMessage("CNAE deve ser informado");

            RuleFor(p => p.AceiteTermosDeUso)
                .NotNull()
                .Must(ValorDeveSerTrue)
                .WithMessage("Deve-se aceitar os termos de Uso");

            RuleFor(p => p.DataCadastro)
                .NotNull()
                .NotEmpty()
                .WithMessage("Data de cadastrado inválida");
        }

        private bool ValorDeveSerTrue(AceiteTermosDeUso arg)
        {
            return arg == true;
        }
    }
}
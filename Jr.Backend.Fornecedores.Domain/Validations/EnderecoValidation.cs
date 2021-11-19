using FluentValidation;
using Jr.Backend.Fornecedores.Domain.ValueObjects;

namespace Jr.Backend.Fornecedores.Domain.Validations
{
    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        public EnderecoValidation()
        {
            RuleFor(p => p.Bairro)
                .NotEmpty()
                .NotNull()
                .WithMessage("Bairro deve ser informado");

            RuleFor(p => p.Cep)
                .NotEmpty()
                .NotNull()
                .WithMessage("Cep deve ser informado");

            RuleFor(p => p.Cidade)
                .NotEmpty()
                .NotNull()
                .WithMessage("Cidade deve ser informado");

            RuleFor(p => p.Uf)
                .NotEmpty()
                .NotNull()
                .WithMessage("Uf deve ser informado");

            RuleFor(p => p.Logradouro)
                .NotEmpty()
                .NotNull()
                .WithMessage("Logradouro deve ser informado");

            RuleFor(p => p.Numero)
                .NotEmpty()
                .NotNull()
                .WithMessage("Numero deve ser informado");
        }
    }
}
using FluentValidation;

namespace Jr.Backend.Fornecedores.Domain.Validations.Emails
{
    public class EmailValidation<T> : AbstractValidator<T>
    {
        public EmailValidation()
        {
            RuleFor(x => x.ToString()).EmailAddress().WithMessage("E-mail informado é inválido");
        }
    }
}
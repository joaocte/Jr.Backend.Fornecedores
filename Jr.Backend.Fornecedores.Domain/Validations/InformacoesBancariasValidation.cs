using FluentValidation;
using Jr.Backend.Fornecedores.Domain.ValueObjects;

namespace Jr.Backend.Fornecedores.Domain.Validations
{
    public class InformacoesBancariasValidation : AbstractValidator<InformacoesBancarias>
    {
        public InformacoesBancariasValidation()
        {
            RuleFor(x => x.Agencia).NotEmpty().NotEmpty().WithMessage("Agencia é obrigatório");
            RuleFor(x => x.TipoConta).NotEmpty().NotEmpty().WithMessage("TipoConta é obrigatório");
            RuleFor(x => x.Banco).NotEmpty().NotEmpty().WithMessage("Banco é obrigatório");
            RuleFor(x => x.Conta).NotEmpty().NotEmpty().WithMessage("Conta é obrigatório");
        }
    }
}
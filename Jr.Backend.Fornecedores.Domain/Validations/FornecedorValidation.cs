using FluentValidation;
using Jr.Backend.Fornecedores.Domain.Validations.Emails;
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

            RuleForEach(x => x.EmailContato).SetValidator(new EmailContatoValidation());
            RuleForEach(x => x.EmailFatura).SetValidator(new EmailFaturaValidation());
            RuleFor(p => p.InformacoesBancarias).SetValidator(new InformacoesBancariasValidation());
            RuleForEach(p => p.Enderecos).SetValidator(new EnderecoValidation());
            RuleFor(p => p.NomeContato)
                .NotNull()
                .NotEmpty()
                .WithMessage("Razão Social ou Nome de Contato deve ser informado");
            RuleFor(p => p.Telefone)
                .NotNull()
                .NotEmpty()
                .WithMessage("Telefone deve ser informado");
        }

        private bool ValorDeveSerTrue(AceiteTermosDeUso arg)
        {
            return arg == true;
        }
    }
}
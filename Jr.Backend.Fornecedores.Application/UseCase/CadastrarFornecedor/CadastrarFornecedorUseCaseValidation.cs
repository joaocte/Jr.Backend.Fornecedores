using AutoMapper;
using Jr.Backend.Fornecedores.Domain.Commands.Reqiest;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Jr.Backend.Fornecedores.Application.UseCase.CadastrarFornecedor
{
    public class CadastrarFornecedorUseCaseValidation : ICadastrarFornecedorUseCase
    {
        private readonly ICadastrarFornecedorUseCase cadastrarFornecedorUseCase;
        private readonly IFornecedorRepository formFornecedorRepository;
        private readonly IMapper mapper;

        public async Task<CadastrarPessoaCommandResponse> Execute(CadastrarPessoaCommand command)
        {
            return await cadastrarFornecedorUseCase.Execute(command);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                cadastrarFornecedorUseCase?.Dispose();
                formFornecedorRepository?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
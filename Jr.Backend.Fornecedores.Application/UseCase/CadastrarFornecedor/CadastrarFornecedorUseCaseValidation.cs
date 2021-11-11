using AutoMapper;
using Jr.Backend.Fornecedores.Domain;
using Jr.Backend.Fornecedores.Domain.Commands.Reqiest;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Infrastructure.Interfaces;
using Jr.Backend.Libs.Domain.Abstractions.Exceptions;
using System.Threading.Tasks;

namespace Jr.Backend.Fornecedores.Application.UseCase.CadastrarFornecedor
{
    public class CadastrarFornecedorUseCaseValidation : ICadastrarFornecedorUseCase
    {
        private readonly ICadastrarFornecedorUseCase cadastrarFornecedorUseCase;
        private readonly IFornecedorRepository fornecedorRepository;
        private readonly IMapper mapper;

        public async Task<CadastrarPessoaCommandResponse> Execute(CadastrarPessoaCommand command)
        {
            var fornecedorDomain = mapper.Map<Fornecedor>(command);

            var fornecedorJaCadastrado = await fornecedorRepository.ExistsAsync(fornecedorDomain.Cnpj);

            if (fornecedorJaCadastrado)
                throw new AlreadyRegisteredException($"Fornecedor {fornecedorDomain.Cnpj} já Cadastrado");

            return await cadastrarFornecedorUseCase.Execute(command);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                cadastrarFornecedorUseCase?.Dispose();
                fornecedorRepository?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
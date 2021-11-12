using AutoMapper;
using Jr.Backend.Fornecedores.Domain;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Domain.ValueObjects;
using Jr.Backend.Fornecedores.Domain.ValueObjects.Endereco;

namespace Jr.Backend.Fornecedores.Application.AutoMapper
{
    public class MappingProfileToDomain : Profile
    {
        public MappingProfileToDomain()
        {
            CreateMap<Fornecedores.Infrastructure.Entity.Comum.InformacoesBancarias, InformacoesBancarias>();
            CreateMap<Fornecedores.Infrastructure.Entity.Comum.Endereco.EnderecoCobranca, EnderecoCobranca>();
            CreateMap<Fornecedores.Infrastructure.Entity.Comum.Endereco.EnderecoComercial, EnderecoComercial>();
            CreateMap<Fornecedores.Infrastructure.Entity.Fornecedor, Fornecedor>();
            CreateMap<CadastrarFornecedorCommand, Fornecedor>();
            CreateMap<AtualizarFornecedorCommand, Fornecedor>();
        }
    }
}
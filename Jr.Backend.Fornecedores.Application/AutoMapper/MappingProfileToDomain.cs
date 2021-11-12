using AutoMapper;
using Jr.Backend.Fornecedores.Domain;
using Jr.Backend.Fornecedores.Domain.Commands;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Domain.ValueObjects;

namespace Jr.Backend.Fornecedores.Application.AutoMapper
{
    public class MappingProfileToDomain : Profile
    {
        public MappingProfileToDomain()
        {
            CreateMap<Fornecedores.Infrastructure.Entity.Comum.InformacoesBancarias, InformacoesBancarias>();
            CreateMap<Fornecedores.Infrastructure.Entity.Comum.Endereco, Endereco>();
            CreateMap<Fornecedores.Infrastructure.Entity.Fornecedor, Fornecedor>();
            CreateMap<FornecedorCommandRequest, Fornecedor>();
            CreateMap<InformacoesBancariasRequest, InformacoesBancarias>();
            CreateMap<EnderecoRequest, Endereco>();
            CreateMap<CadastrarFornecedorCommand, Fornecedor>();
            CreateMap<AtualizarFornecedorCommand, Fornecedor>();
        }
    }
}
using AutoMapper;
using Jr.Backend.Fornecedores.Domain;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Domain.ValueObjects;
using Jr.Backend.Fornecedores.Domain.ValueObjects.Endereco;

namespace Jr.Backend.Fornecedores.Application.AutoMapper
{
    public class MappingProfileToEntity : Profile
    {
        public MappingProfileToEntity()
        {
            CreateMap<InformacoesBancarias, Fornecedores.Infrastructure.Entity.Comum.InformacoesBancarias>();
            CreateMap<EnderecoCobranca, Fornecedores.Infrastructure.Entity.Comum.Endereco.EnderecoCobranca>();
            CreateMap<EnderecoComercial, Fornecedores.Infrastructure.Entity.Comum.Endereco.EnderecoComercial>();
            CreateMap<Fornecedor, Fornecedores.Infrastructure.Entity.Fornecedor>();
            CreateMap<AtualizarFornecedorCommand, Fornecedores.Infrastructure.Entity.Fornecedor>();
        }
    }
}
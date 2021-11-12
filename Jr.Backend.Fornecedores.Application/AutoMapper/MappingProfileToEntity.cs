using AutoMapper;
using Jr.Backend.Fornecedores.Domain;
using Jr.Backend.Fornecedores.Domain.Commands;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Domain.ValueObjects;

namespace Jr.Backend.Fornecedores.Application.AutoMapper
{
    public class MappingProfileToEntity : Profile
    {
        public MappingProfileToEntity()
        {
            CreateMap<InformacoesBancarias, Infrastructure.Entity.Comum.InformacoesBancarias>();
            CreateMap<Endereco, Infrastructure.Entity.Comum.Endereco>();
            CreateMap<Fornecedor, Infrastructure.Entity.Fornecedor>();
            CreateMap<AtualizarFornecedorCommand, Infrastructure.Entity.Fornecedor>();
            CreateMap<FornecedorCommandRequest, Infrastructure.Entity.Fornecedor>();
            CreateMap<InformacoesBancariasRequest, Infrastructure.Entity.Comum.InformacoesBancarias>();
        }
    }
}
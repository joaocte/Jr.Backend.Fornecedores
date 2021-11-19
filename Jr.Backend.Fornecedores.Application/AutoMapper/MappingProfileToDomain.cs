using AutoMapper;
using Jr.Backend.Fornecedores.Domain.Commands;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Infrastructure.Entity;
using Jr.Backend.Fornecedores.Infrastructure.Entity.Comum;
using CnaesSecundario = Jr.Backend.Fornecedores.Infrastructure.Entity.Comum.CnaesSecundario;
using Qsa = Jr.Backend.Fornecedores.Infrastructure.Entity.Comum.Qsa;

namespace Jr.Backend.Fornecedores.Application.AutoMapper
{
    public class MappingProfileToDomain : Profile
    {
        public MappingProfileToDomain()
        {
            CreateMap<InformacoesBancarias, Domain.ValueObjects.InformacoesBancarias>();
            CreateMap<Endereco, Domain.ValueObjects.Endereco>();
            CreateMap<Fornecedor, Domain.Fornecedor>();
            CreateMap<FornecedorCommandRequest, Domain.Fornecedor>();
            CreateMap<InformacoesBancariasRequest, Domain.ValueObjects.InformacoesBancarias>();
            CreateMap<Qsa, Domain.ValueObjects.Qsa>();
            CreateMap<CnaesSecundario, Domain.ValueObjects.CnaesSecundario>();
            CreateMap<EnderecoRequest, Domain.ValueObjects.Endereco>();
            CreateMap<CadastrarFornecedorCommand, Domain.Fornecedor>();
            CreateMap<AtualizarFornecedorCommand, Domain.Fornecedor>();
        }
    }
}
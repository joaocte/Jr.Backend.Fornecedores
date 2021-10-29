using AutoMapper;
using Jr.Backend.Fornecedores.Domain;
using Jr.Backend.Fornecedores.Domain.ValueObjects;
using Jr.Backend.Fornecedores.Domain.ValueObjects.Endereco;

namespace Jr.Backend.Pessoa.Application.AutoMapper
{
    public class MappingProfileToDomain : Profile
    {
        public MappingProfileToDomain()
        {
            CreateMap<bool, AceiteTermosDeUso>();
            CreateMap<string, Agencia>();
            CreateMap<string, Area>();
            CreateMap<string, Bairro>();
            CreateMap<string, Banco>();
            CreateMap<string, Cargo>();
            CreateMap<string, Celular>();
            CreateMap<string, Cep>();
            CreateMap<string, Cidade>();
            CreateMap<string, CNAE>();
            CreateMap<string, Cnpj>();
            CreateMap<string, Complemento>();
            CreateMap<string, Conta>();
            CreateMap<string, EmailContato>();
            CreateMap<string, EmailFatura>();
            CreateMap<string, Estado>();
            CreateMap<string, Logradouro>();
            CreateMap<string, NomeCompleto>();
            CreateMap<string, Numero>();
            CreateMap<decimal, Telefone>();
            CreateMap<decimal, PercentualCapitalSocial>();
            CreateMap<Fornecedores.Infrastructure.Entity.Comum.InformacoesBancarias, InformacoesBancarias>();
            CreateMap<Fornecedores.Infrastructure.Entity.Comum.Endereco.EnderecoCobranca, EnderecoCobranca>();
            CreateMap<Fornecedores.Infrastructure.Entity.Comum.Endereco.EnderecoComercial, EnderecoComercial>();
            CreateMap<Fornecedores.Infrastructure.Entity.Fornecedor, Fornecedor>();
        }
    }
}
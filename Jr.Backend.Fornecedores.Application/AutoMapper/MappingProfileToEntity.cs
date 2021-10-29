using AutoMapper;
using Jr.Backend.Fornecedores.Domain;
using Jr.Backend.Fornecedores.Domain.ValueObjects;
using Jr.Backend.Fornecedores.Domain.ValueObjects.Endereco;

namespace Jr.Backend.Pessoa.Application.AutoMapper
{
    public class MappingProfileToEntity : Profile
    {
        public MappingProfileToEntity()
        {
            CreateMap<AceiteTermosDeUso, bool>();
            CreateMap<Agencia, string>();
            CreateMap<Area, string>();
            CreateMap<Bairro, string>();
            CreateMap<Banco, string>();
            CreateMap<Cargo, string>();
            CreateMap<Celular, string>();
            CreateMap<Cep, string>();
            CreateMap<Cidade, string>();
            CreateMap<CNAE, string>();
            CreateMap<Cnpj, string>();
            CreateMap<Complemento, string>();
            CreateMap<Conta, string>();
            CreateMap<EmailContato, string>();
            CreateMap<EmailFatura, string>();
            CreateMap<Estado, string>();
            CreateMap<Logradouro, string>();
            CreateMap<NomeCompleto, string>();
            CreateMap<Numero, string>();
            CreateMap<Telefone, string>();
            CreateMap<PercentualCapitalSocial, decimal>();
            CreateMap<InformacoesBancarias, Fornecedores.Infrastructure.Entity.Comum.InformacoesBancarias>();
            CreateMap<EnderecoCobranca, Fornecedores.Infrastructure.Entity.Comum.Endereco.EnderecoCobranca>();
            CreateMap<EnderecoComercial, Fornecedores.Infrastructure.Entity.Comum.Endereco.EnderecoComercial>();
            CreateMap<Fornecedor, Fornecedores.Infrastructure.Entity.Fornecedor>();
        }
    }
}
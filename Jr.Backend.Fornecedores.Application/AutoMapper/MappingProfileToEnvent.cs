using AutoMapper;
using Jr.Backend.Message.Events.Fornecedor.Comum;
using Jr.Backend.Message.Events.Fornecedor.Comum.Endereco;
using Jr.Backend.Message.Events.Fornecedor.Events;

namespace Jr.Backend.Fornecedores.Application.AutoMapper
{
    public class MappingProfileToEnvent : Profile
    {
        public MappingProfileToEnvent()
        {
            CreateMap<Fornecedores.Infrastructure.Entity.Comum.InformacoesBancarias, InformacoesBancarias>();
            CreateMap<Fornecedores.Infrastructure.Entity.Comum.Endereco.EnderecoCobranca, EnderecoCobranca>();
            CreateMap<Fornecedores.Infrastructure.Entity.Comum.Endereco.EnderecoComercial, EnderecoComercial>();
            CreateMap<Fornecedores.Infrastructure.Entity.Fornecedor, FornecedorCadastradoEvent>();
        }
    }
}
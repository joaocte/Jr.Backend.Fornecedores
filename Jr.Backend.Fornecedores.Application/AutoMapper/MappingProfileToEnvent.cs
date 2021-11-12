using AutoMapper;
using Jr.Backend.Fornecedores.Domain.Commands;
using Jr.Backend.Message.Events.Fornecedor.Events;
using Jr.Backend.Message.Share.Fornecedor;
using Jr.Backend.Message.Share.Fornecedor.Endereco;

namespace Jr.Backend.Fornecedores.Application.AutoMapper
{
    public class MappingProfileToEnvent : Profile
    {
        public MappingProfileToEnvent()
        {
            CreateMap<Fornecedores.Infrastructure.Entity.Comum.InformacoesBancarias, InformacoesBancarias>();
            CreateMap<Fornecedores.Infrastructure.Entity.Comum.Endereco, EnderecoCobranca>();
            CreateMap<Infrastructure.Entity.Fornecedor, FornecedorCadastradoEvent>();
            CreateMap<Infrastructure.Entity.Fornecedor, FornecedorAtualizadoEvent>();
            CreateMap<Infrastructure.Entity.Fornecedor, FornecedorDeletadoEvent>();
            CreateMap<FornecedorCommandRequest, FornecedorDeletadoEvent>();

            CreateMap<InformacoesBancariasRequest, InformacoesBancarias>();
        }
    }
}
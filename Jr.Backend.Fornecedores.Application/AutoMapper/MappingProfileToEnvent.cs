using AutoMapper;
using Jr.Backend.Fornecedores.Domain.Commands;
using Jr.Backend.Fornecedores.Infrastructure.Entity;
using Jr.Backend.Fornecedores.Infrastructure.Entity.Comum;
using Jr.Backend.Message.Events.Fornecedor.Events;
using Jr.Backend.Message.Share.Fornecedor.Endereco;
using Endereco = Jr.Backend.Fornecedores.Infrastructure.Entity.Comum.Endereco;

namespace Jr.Backend.Fornecedores.Application.AutoMapper
{
    public class MappingProfileToEnvent : Profile
    {
        public MappingProfileToEnvent()
        {
            CreateMap<InformacoesBancarias, Message.Share.Fornecedor.InformacoesBancarias>();
            CreateMap<Endereco, EnderecoCobranca>();
            CreateMap<InformacoesBancariasRequest, Message.Share.Fornecedor.InformacoesBancarias>();
            CreateMap<FornecedorCommandRequest, FornecedorDeletadoEvent>();
            CreateMap<Fornecedor, FornecedorCadastradoEvent>();
            CreateMap<Fornecedor, FornecedorAtualizadoEvent>();
            CreateMap<Fornecedor, FornecedorDeletadoEvent>();
        }
    }
}
using AutoMapper;
using Jr.Backend.Fornecedores.Domain.Commands;
using Jr.Backend.Fornecedores.Infrastructure.Entity;
using Jr.Backend.Fornecedores.Infrastructure.Entity.Comum;
using Jr.Backend.Message.Events.Fornecedor.Events;
using CnaesSecundario = Jr.Backend.Fornecedores.Infrastructure.Entity.Comum.CnaesSecundario;
using Endereco = Jr.Backend.Fornecedores.Infrastructure.Entity.Comum.Endereco;
using Qsa = Jr.Backend.Fornecedores.Infrastructure.Entity.Comum.Qsa;

namespace Jr.Backend.Fornecedores.Application.AutoMapper
{
    public class MappingProfileToEnvent : Profile
    {
        public MappingProfileToEnvent()
        {
            CreateMap<InformacoesBancarias, Message.Share.Fornecedor.InformacoesBancarias>();
            CreateMap<Endereco, Message.Share.Fornecedor.Endereco>();
            CreateMap<InformacoesBancariasRequest, Message.Share.Fornecedor.InformacoesBancarias>();
            CreateMap<Qsa, Message.Share.Fornecedor.Qsa>();
            CreateMap<CnaesSecundario, Message.Share.Fornecedor.CnaesSecundario>();
            CreateMap<Fornecedor, FornecedorCadastradoEvent>();
            CreateMap<Fornecedor, FornecedorAtualizadoEvent>();
            CreateMap<Fornecedor, FornecedorDeletadoEvent>();
        }
    }
}
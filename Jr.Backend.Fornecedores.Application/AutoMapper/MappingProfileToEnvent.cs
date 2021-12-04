using AutoMapper;
using Jr.Backend.Fornecedores.Domain.Commands;
using Jr.Backend.Fornecedores.Infrastructure.Entity;
using Jr.Backend.Fornecedores.Infrastructure.Entity.Comum;
using Jror.Backend.Message.Events.Fornecedor.Events;
using CnaesSecundario = Jr.Backend.Fornecedores.Infrastructure.Entity.Comum.CnaesSecundario;
using Endereco = Jr.Backend.Fornecedores.Infrastructure.Entity.Comum.Endereco;
using Qsa = Jr.Backend.Fornecedores.Infrastructure.Entity.Comum.Qsa;

namespace Jr.Backend.Fornecedores.Application.AutoMapper
{
    public class MappingProfileToEnvent : Profile
    {
        public MappingProfileToEnvent()
        {
            CreateMap<InformacoesBancarias, Jror.Backend.Message.Share.Fornecedor.InformacoesBancarias>();
            CreateMap<Endereco, Jror.Backend.Message.Share.Fornecedor.Endereco>();
            CreateMap<InformacoesBancariasRequest, Jror.Backend.Message.Share.Fornecedor.InformacoesBancarias>();
            CreateMap<Qsa, Jror.Backend.Message.Share.Fornecedor.Qsa>();
            CreateMap<CnaesSecundario, Jror.Backend.Message.Share.Fornecedor.CnaesSecundario>();
            CreateMap<Fornecedor, FornecedorCadastradoEvent>();
            CreateMap<Fornecedor, FornecedorAtualizadoEvent>();
            CreateMap<Fornecedor, FornecedorDeletadoEvent>();
        }
    }
}
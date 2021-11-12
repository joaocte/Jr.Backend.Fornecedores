using AutoMapper;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
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
            CreateMap<Fornecedores.Infrastructure.Entity.Comum.Endereco.EnderecoCobranca, EnderecoCobranca>();
            CreateMap<Fornecedores.Infrastructure.Entity.Comum.Endereco.EnderecoComercial, EnderecoComercial>();
            CreateMap<Infrastructure.Entity.Fornecedor, FornecedorCadastradoEvent>();
            CreateMap<Infrastructure.Entity.Fornecedor, FornecedorAtulizadoEvent>();
            CreateMap<Infrastructure.Entity.Fornecedor, FornecedorDeletadoEvent>();
            CreateMap<AtualizarFornecedorCommand, FornecedorAtulizadoEvent>();
        }
    }
}
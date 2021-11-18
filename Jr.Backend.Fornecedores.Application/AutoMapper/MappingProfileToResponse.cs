using AutoMapper;
using Jr.Backend.Fornecedores.Domain.Commands.Response;
using Jr.Backend.Fornecedores.Infrastructure.Entity;

namespace Jr.Backend.Fornecedores.Application.AutoMapper
{
    public class MappingProfileToResponse : Profile
    {
        public MappingProfileToResponse()
        {
            CreateMap<Fornecedor, AtualizarFornecedorCommandResponse>();
        }
    }
}
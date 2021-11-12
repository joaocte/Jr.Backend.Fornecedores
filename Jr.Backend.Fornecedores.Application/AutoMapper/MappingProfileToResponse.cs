using AutoMapper;
using Jr.Backend.Fornecedores.Domain.Commands.Response;

namespace Jr.Backend.Fornecedores.Application.AutoMapper
{
    public class MappingProfileToResponse : Profile
    {
        public MappingProfileToResponse()
        {
            CreateMap<Infrastructure.Entity.Fornecedor, AtualizarFornecedorCommandResponse>();
        }
    }
}
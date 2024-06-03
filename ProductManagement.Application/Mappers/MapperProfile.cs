using AutoMapper;
using ProductManagement.Domain.Entities;
using ProductManagement.Application.DTOs;

namespace ProductManagement.Application.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<Fornecedor, FornecedorDTO>().ReverseMap();
        }
    }
}

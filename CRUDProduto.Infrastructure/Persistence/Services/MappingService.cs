using AutoMapper;
using CRUDProduto.Core.Dtos;
using CRUDProduto.Core.Entities;

namespace CRUDProduto.Infrastructure.Persistence.Services
{
    public class MappingService : Profile
    {
        public MappingService()
        {
            CreateMap<Produto, ProdutoDTO>();
            CreateMap<ProdutoDTO, Produto>();
            CreateMap<CategoriaDTO, Categoria>();
            CreateMap<Categoria, CategoriaDTO>();
        }
    }
}

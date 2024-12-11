using CRUDProduto.Core.Entities;
using CRUDProduto.Core.Dtos;

namespace CRUDProduto.Core.Services
{
    public interface ICategoriaService
    {
        Task CreateCategoriaAsync(CategoriaDTO categoria);
        Task DeleteCategoriaAsync(Guid id);
        Task UpdateCategoriaAsync(Categoria categoria);
        Task<IEnumerable<CategoriaDTO>> GetCategoriasAsync();
        Task<CategoriaDTO> GetCategoriaByIdAsync(Guid id);
    }
}

using CRUDProduto.Core.Dtos;

namespace CRUDProduto.Application.Interfaces.Services
{
    public interface ICategoriaAppService
    {
        Task CreateCategoriaAsync(CategoriaDTO categoriaDto);
        Task DeleteCategoriaAsync(Guid id);
        Task UpdateCategoriaAsync(CategoriaDTO categoriaDto);
        Task<IEnumerable<CategoriaDTO>> GetCategoriasAsync();
        Task<CategoriaDTO> GetCategoriaByIdAsync(Guid id);
    }
}

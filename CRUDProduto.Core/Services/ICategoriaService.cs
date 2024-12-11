using CRUDProduto.Core.Entities;

namespace CRUDProduto.Core.Services
{
    public interface ICategoriaService
    {
        Task CreateCategoriaAsync(Categoria categoria);
        Task DeleteCategoriaAsync(Guid id);
        Task UpdateCategoriaAsync(Categoria categoria);
        Task<IEnumerable<Categoria?>> GetCategoriasAsync();
        Task<Categoria?> GetCategoriaByIdAsync(Guid id);
    }
}

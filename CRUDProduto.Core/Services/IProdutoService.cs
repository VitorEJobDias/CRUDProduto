using CRUDProduto.Core.Entities;

namespace CRUDProduto.Core.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto?>> GetProdutosAsync();
        Task<Produto?> GetProdutoByIdAsync(Guid id);
        Task CreateProdutoAsync(Produto produto);
        Task DeleteProdutoAsync(Guid id);
        Task UpdateProdutoAsync(Produto produto);
    }
}

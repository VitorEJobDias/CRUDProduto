using CRUDProduto.Core.Entities;

namespace CRUDProduto.Core.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        Task<IEnumerable<Produto?>> GetProdutosAsync();
        Task<Produto?> GetProdutoByIdAsync(Guid id);
        Task CreateProdutoAsync(Produto produto);
        void UpdateProduto(Produto produto);
        Task DeleteAsync(Guid id);
    }
}

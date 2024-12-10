using CRUDProduto.Core.Entities;

namespace CRUDProduto.Core.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        Task<IEnumerable<Produto?>> GetProdutosAsync();
        Task<Produto> GetProdutoByIdAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}

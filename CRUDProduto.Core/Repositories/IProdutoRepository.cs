using CRUDProduto.Core.Entities;
using System.Linq.Expressions;

namespace CRUDProduto.Core.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        Task<IEnumerable<Produto?>> GetProdutosAsync(Expression<Func<Produto, bool>> consulta, Func<IQueryable<Produto>, IQueryable<Produto>>? include = null, bool tracking = false);
        Task<Produto?> GetProdutoByIdAsync(Guid id);
        Task CreateProdutoAsync(Produto produto);
        void UpdateProduto(Produto produto);
        Task DeleteAsync(Guid id);
    }
}

using CRUDProduto.Core.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace CRUDProduto.Core.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        Task<IEnumerable<Produto?>> GetProdutosAsync(Expression<Func<Produto, bool>> consulta, Func<IQueryable<Produto>, IIncludableQueryable<Produto, object>>? include = null, bool tracking = false);
        Task<Produto?> GetProdutoByIdAsync(Guid id);
        Task CreateProdutoAsync(Produto produto);
        void UpdateProduto(Produto produto);
        Task DeleteAsync(Guid id);
    }
}

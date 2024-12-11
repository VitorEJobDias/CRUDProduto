using CRUDProduto.Core.Entities;
using CRUDProduto.Core.Repositories;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace CRUDProduto.Infrastructure.Persistence.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {

        public ProdutoRepository(CRUDProdutoContext context) : base(context) { }

        public async Task DeleteAsync(Guid id)
        {
            var produto = await Search(p => p.Id == id);
            if (produto != null && produto.Any())
            {
                var produtoDelete = produto.First();
                produtoDelete.Delete();
                Update(produtoDelete);
            }
        }

        public async Task CreateProdutoAsync(Produto produto)
        {
            await CreateAsync(produto);
        }

        public void UpdateProduto(Produto produto)
        {
            Update(produto);
        }

        public async Task<Produto?> GetProdutoByIdAsync(Guid id)
        {
            var produto = await Search(p => p.Id == id);
            return produto.FirstOrDefault();
        }

        public async Task<IEnumerable<Produto?>> GetProdutosAsync(Expression<Func<Produto, bool>> consulta, Func<IQueryable<Produto>, IIncludableQueryable<Produto, object>>? include = null, bool tracking = false) =>
            await Search(consulta, include, tracking);
    }
}

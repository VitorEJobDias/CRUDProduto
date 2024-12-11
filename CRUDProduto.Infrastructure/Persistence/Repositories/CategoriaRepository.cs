using Microsoft.EntityFrameworkCore.Query;
using CRUDProduto.Core.Repositories;
using CRUDProduto.Core.Entities;
using System.Linq.Expressions;

namespace CRUDProduto.Infrastructure.Persistence.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(CRUDProdutoContext context) : base(context) { }

        public async Task DeleteAsync(Guid id)
        {
            var categoria = await Search(p => p.Id == id);
            if (categoria != null && categoria.Any())
            {
                var categoriaDelete = categoria.First();
                categoriaDelete.Delete();
                Update(categoriaDelete);
            }
        }

        public void UpdateCategoria(Categoria categoria)
        {
            Update(categoria);
        }

        public async Task CreateCategoriaAsync(Categoria categoria)
        {
            await CreateAsync(categoria);
        }

        public async Task<IEnumerable<Categoria?>> GetCategoriasAsync(Expression<Func<Categoria, bool>> consulta, Func<IQueryable<Categoria>, IIncludableQueryable<Categoria, object>>? include = null, bool tracking = false) =>
            await Search(consulta, include, tracking);

        public async Task<Categoria?> GetCategoriaByIdAsync(Guid id)
        {
            var categorias = await Search(c => c.Id == id, null, false);
            return categorias.FirstOrDefault();
        }
    }
}

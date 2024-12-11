using CRUDProduto.Core.Entities;
using CRUDProduto.Core.Repositories;

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

        public async Task<IEnumerable<Categoria?>> GetCategoriasAsync() =>
            await Search(c => true, null, false);

        public async Task<Categoria?> GetCategoriaByIdAsync(Guid id)
        {
            var categorias = await Search(c => c.Id == id, null, false);
            return categorias.FirstOrDefault();
        }
    }
}

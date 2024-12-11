using CRUDProduto.Infrastructure.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;
using CRUDProduto.Core.Entities;
using CRUDProduto.Core.Common;

namespace CRUDProduto.Infrastructure.Persistence
{
    public class CRUDProdutoContext : DbContext
    {
        public CRUDProdutoContext(DbContextOptions<CRUDProdutoContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());                    

            base.OnModelCreating(modelBuilder);
        }
    }
}

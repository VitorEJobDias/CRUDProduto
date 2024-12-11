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

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var method = typeof(BaseMap).GetMethod(nameof(BaseMap.ConfigureBase));
                    var genericMethod = method.MakeGenericMethod(entityType.ClrType);
                    genericMethod.Invoke(null, new object[] { modelBuilder.Entity(entityType.ClrType) });
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}

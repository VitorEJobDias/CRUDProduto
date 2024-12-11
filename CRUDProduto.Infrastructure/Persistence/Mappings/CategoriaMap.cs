using CRUDProduto.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUDProduto.Infrastructure.Persistence.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("tbCategoria");
            builder.ConfigureBase();

            builder.HasKey(p => p.Id);  
            builder.Property(p => p.Active).IsRequired();  
            builder.Property(p => p.Nome).IsRequired();

            builder.HasMany(c => c.Produtos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(c => c.IdCategoria)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

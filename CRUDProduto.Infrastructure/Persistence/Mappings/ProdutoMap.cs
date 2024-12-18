﻿using CRUDProduto.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUDProduto.Infrastructure.Persistence.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ConfigureBase();
            builder.HasKey(p => p.Id);  
            builder.Property(p => p.Active).IsRequired();  
            builder.Property(p => p.Preco).IsRequired();  
            builder.Property(p => p.Nome).IsRequired();  
            builder.Property(p => p.IdCategoria).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.IdCategoria)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

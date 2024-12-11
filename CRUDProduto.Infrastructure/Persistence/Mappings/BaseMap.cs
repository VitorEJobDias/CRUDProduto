using CRUDProduto.Core.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUDProduto.Infrastructure.Persistence.Mappings
{
    public static class BaseMap
    {
        public static void ConfigureBase<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : BaseEntity
        {
            builder.Property(e => e.Active)
                   .HasDefaultValue(true);

            builder.Property(e => e.Created)
                   .ValueGeneratedOnAdd()
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}

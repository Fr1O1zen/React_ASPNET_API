using Chempions.Common.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chempions.Data.Sql.DAO_conf;

public class ProductConf : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(c => c.Producent).IsRequired();
        builder.Property(c => c.Nazwa).IsRequired();
        builder.Property(c => c.CenaNetto).IsRequired();
        builder.Property(c=>c.Kategoria).HasMaxLength(30);
        builder.Property(c=>c.Nazwa).HasMaxLength(30);
        builder.Property(c=>c.Producent).HasMaxLength(30);
    }
}
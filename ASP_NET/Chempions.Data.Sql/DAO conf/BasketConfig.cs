using Chempions.Common.DAO;

namespace Chempions.Data.Sql.DAO_conf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
public class BasketConfig : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        builder.Property(c => c.IdKosz).IsRequired();
        builder.Property(c => c.Ilosc).IsRequired();

        builder.HasOne(x => x.Product)
            .WithMany(x => x.Baskets)
            .OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(x => x.IdProd);

        builder.HasOne(x => x.Order)
            .WithMany(x => x.Baskets)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(x => x.IdZam);
        
        builder.ToTable("Basket");
    }
}
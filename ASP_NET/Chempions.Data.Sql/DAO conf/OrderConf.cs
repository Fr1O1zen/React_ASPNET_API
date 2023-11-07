using Chempions.Common.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chempions.Data.Sql.DAO_conf;

public class OrderConf : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        /////////////////////////////////
        builder.Property(c => c.StatusRealizacji).HasColumnType("tinyint(1)");
        /////////////////////////////////
        
        ////////////////////////////////////////
        builder.Property(c => c.IdZam).IsRequired();
        builder.Property(c => c.StatusRealizacji).IsRequired();
        builder.Property(c => c.StatusRealizacji).IsRequired();
        builder.Property(c => c.StatusRealizacji).IsRequired();
        builder.Property(c => c.StatusRealizacji).IsRequired();
        /////////////////////////////////////////

        builder.HasOne(x => x.Invoice)
            .WithOne(x => x.Order)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey<Order>(x => x.IdFakt);

        builder.HasOne(x => x.Client)
            .WithMany(x => x.Orders)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(x => x.IdKlient);



       builder.ToTable("Order");
    }
}
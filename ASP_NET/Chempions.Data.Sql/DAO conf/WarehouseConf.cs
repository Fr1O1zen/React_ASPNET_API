using Chempions.Common.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chempions.Data.Sql.DAO_conf;

public class WarehouseConf : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        
        /////////////////////////////////////////////////////////////////
        builder.Property(c => c.Partia).IsRequired();
        builder.Property(c => c.DataWaznosci).IsRequired();
        builder.Property(c => c.Partia).HasMaxLength(30);
        ////////////////////////////////////////////////////////////////

        builder.HasOne(d => d.Product)
            .WithMany(p => p.Warehouses)
            .OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(d => d.Idprod);

    }
}
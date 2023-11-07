using Chempions.Common.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chempions.Data.Sql.DAO_conf;

public class InvoiceConf : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.Property(c => c.StautsOplacenia).HasColumnType("tinyint(1)");
        builder.Property(c => c.IdFakt).IsRequired();
        builder.Property(c => c.StautsOplacenia).IsRequired();
        builder.Property(c => c.IdKlient).IsRequired();

        builder.HasOne(x => x.Order)
            .WithOne(x => x.Invoice)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey<Order>(x => x.IdFakt);

        builder.HasOne(x => x.Client)
            .WithMany(x => x.Invoices)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(x => x.IdKlient);





        builder.ToTable("Invoice");
    }
}
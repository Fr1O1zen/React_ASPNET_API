using Chempions.Common.DAO;

namespace Chempions.Data.Sql.DAO_conf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ClientConf : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.Property(c => c.NIP).IsRequired();
        builder.Property(c => c.NazwaFirmy).IsRequired();
        builder.Property(c => c.IdKlient).IsRequired();
        builder.Property(c => c.Nazwisko).IsRequired();
        

        builder.ToTable("Client");
    }
}
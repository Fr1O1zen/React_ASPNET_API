using Chempions.Common.DAO;
using Chempions.Data.Sql.DAO_conf;
using Microsoft.EntityFrameworkCore;

namespace Chempions.Data.Sql;

public class ChempionsDbContext : DbContext
{
    public ChempionsDbContext(DbContextOptions<ChempionsDbContext> options) : base(options){}
    
    public virtual DbSet<Basket> Basket { get; set; }
    public virtual DbSet<Client>  Client { get; set; }
    public virtual DbSet<Invoice> Invoice { get; set; }
    public virtual DbSet<Order> Order { get; set; }
    public virtual DbSet<Product> Product { get; set; }
    public virtual DbSet<Warehouse>  Warehouse{ get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
         builder.ApplyConfiguration(new BasketConfig());
         builder.ApplyConfiguration(new ClientConf());
         builder.ApplyConfiguration(new InvoiceConf());
         builder.ApplyConfiguration(new OrderConf());
         builder.ApplyConfiguration(new ProductConf());
         builder.ApplyConfiguration(new WarehouseConf());
    }

}
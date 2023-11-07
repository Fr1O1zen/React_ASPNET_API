using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Chempions.Common.DAO;

public class Product
{
    public Product()
    {
        Warehouses = new HashSet<Warehouse>();
        Baskets = new HashSet<Basket>();
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int   Idprod { get; set; }
    public string Nazwa { get; set; }= null!;
    public string Producent { get; set; } = null!;
    public string Kategoria { get; set; }= null!;
    public float CenaNetto { get; set; }
    public double CenaBrutto { get; set; }

    public virtual ICollection<Warehouse> Warehouses { get; set; }
    public virtual ICollection<Basket> Baskets { get; set; }

}
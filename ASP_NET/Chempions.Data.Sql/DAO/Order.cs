using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chempions.Common.DAO;

public class Order
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IdZam { get; set; }
    public DateTime  DeadLine { get; set; }
    public bool StatusRealizacji { get; set; }

    public virtual Client Client { get; set; } = null!;
    public int IdKlient { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;
     public int IdFakt { get; set; }

     public virtual ICollection<Basket> Baskets { get; set; } = null!;


}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chempions.Common.DAO;

public class Basket
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IdKosz  { get; set; }
    public int Ilosc { get; set; }

    public virtual Order Order { get; set; } = null!;
    public int IdZam { get; set; }

    public virtual Product Product { get; set; } = null!;
    public int IdProd { get; set; }
    

}
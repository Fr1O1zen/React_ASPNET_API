using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Chempions.Common.DAO;

public class Warehouse
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int  Idlp { get; set; }
    public DateTime  DataWaznosci { get; set; }
    public int Ilosc { get; set; }
    public string Partia { get; set; } = null!;
    public int Idprod { get; set; }

    public virtual Product Product{ get; set; } = null!;
}
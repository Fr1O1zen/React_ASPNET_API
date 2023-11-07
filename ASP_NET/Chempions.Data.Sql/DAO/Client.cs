using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic;

namespace Chempions.Common.DAO;

public class Client
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IdKlient { get; set; }

    public string NazwaFirmy { get; set; } = null!;
    public int NIP { get; set; }
    public string Imie { get; set; }= null!;
    public string Nazwisko { get; set; }= null!;


    public virtual ICollection<Order> Orders { get; set; } = null!;
    public virtual ICollection<Invoice> Invoices { get; set; } = null!;
}
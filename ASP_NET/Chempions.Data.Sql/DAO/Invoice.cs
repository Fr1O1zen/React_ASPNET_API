using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chempions.Common.DAO;

public class Invoice
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IdFakt { get; set; }
    public DateTime DataWyst { get; set; }
    public float CenaBrutto { get; set; }
    public float CenaNetto { get; set; }
    public bool StautsOplacenia { get; set; }

    public virtual Client Client { get; set; } = null!;
    public int IdKlient { get; set; }

    public virtual Order Order { get; set; } = null!;

}
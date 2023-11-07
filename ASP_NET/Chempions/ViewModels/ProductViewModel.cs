namespace Chempions.ViewModels;

public class ProductViewModel
{
    public int   Idprod { get; set; }
    public string Nazwa { get; set; }= null!;
    public string Producent { get; set; } = null!;
    public string Kategoria { get; set; }= null!;
    public float CenaNetto { get; set; }
    public double CenaBrutto { get; set; }

}
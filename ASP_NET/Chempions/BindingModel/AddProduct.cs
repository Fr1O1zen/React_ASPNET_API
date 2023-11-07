using System.ComponentModel.DataAnnotations;

namespace Chempions.BindingModel;

public class AddProduct
{
    [Required]
    [Display(Name="Nazwa")]
    public string Nazwa { get; set; }
    
    [Required]
    [Display(Name="Producent")]
    public string Producent { get; set; }
    
    [Required]
    [Display(Name="Kategoria")]
    public string Kategoria { get; set; }
    
    [Required]
    [Display(Name="CenaNetto")]
    public float CenaNetto { get; set; }
    
    [Required]
    [Display(Name="CenaBrutto")]
    public float CenaBrutto { get; set; }
    
}
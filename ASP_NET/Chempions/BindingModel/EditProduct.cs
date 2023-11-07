using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Chempions.BindingModel;

public class EditProduct
{
   // [Required]
    [Display(Name="Nazwa")]
    public string Nazwa { get; set; }
    
   // [Required]
    [Display(Name="Producent")]
    public string Producent { get; set; }
    
  //  [Required]
    [Display(Name="CenaNetto")]
    public float CenaNetto { get; set; }
    
   // [Required]
    [Display(Name="CenaBrutto")]
    public float CenaBrutto { get; set; }

}

public class EditProductValidator : AbstractValidator<EditProduct>
{
 public EditProductValidator()
 {
  RuleFor(x => x.Nazwa).NotNull();
  RuleFor(x => x.Producent);
  RuleFor(x => x.CenaNetto);
  RuleFor(x => x.CenaBrutto);
 }
 
}
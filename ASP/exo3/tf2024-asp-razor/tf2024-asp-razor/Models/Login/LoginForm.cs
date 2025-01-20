using System.ComponentModel.DataAnnotations;

namespace tf2024_asp_razor.Models.Login;
public class LoginForm
{
    [Required]
    [RegularExpression(".{5,}", ErrorMessage ="Must contain 5 or more character")]
    public string UserName {get;set;}
    [Required]
    [RegularExpression(".{5,}",ErrorMessage ="Must contain 5 or more character")]
    [DataType(DataType.Password)]
    public string Password {get;set;}
}
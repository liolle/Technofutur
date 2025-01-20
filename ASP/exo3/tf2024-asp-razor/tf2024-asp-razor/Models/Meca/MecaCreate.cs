using System.ComponentModel.DataAnnotations;
using tf2024_asp_razor.Models.Entities;
using tf2024_asp_razor.Models.Entities.Taxable;

namespace tf2024_asp_razor.Models.Meca;

public class MecaCreate
{

    [Required(ErrorMessage ="Enter a name")]
    public string? Name { get; set; }

    [Required(ErrorMessage ="Enter an Adresse")]
    public string? Address { get; set; }

    [Required(ErrorMessage ="Enter a phone number")]
    [RegularExpression("0[1-9]{7}", ErrorMessage ="Enter a valid phone number")]
    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }

    public MecanicEntity ToEntity(){
        return new MecanicEntity(){
            Name = Name,
            Address = Address,
            PhoneNumber = PhoneNumber
        };
    }
}
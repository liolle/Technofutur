using System.ComponentModel.DataAnnotations;
using tf2024_asp_razor.Models.Entities;

namespace tf2024_asp_razor.Models.Plane;

public class PlaneTypeCreate
{
    [Required(ErrorMessage ="Enter a plane name")]
    [DataType(DataType.Text)]
    public string Name { get; set; }

    [DataType(DataType.Text)]
    [Required(ErrorMessage ="Enter a Constructor")]
    public string Constructor { get; set; }

    public float Power { get; set; }

    [Required(ErrorMessage ="Enter the plane capacity")]
    public int NbPlace { get; set; }

       public PlaneTypeEntity ToEntity(){
        return new PlaneTypeEntity(){
            Name = Name,
            Constructor = Constructor,
            Power = Power,
            NbPlace = NbPlace
        };
    }
}

public class PlaneTypeList (IEnumerable<PlaneTypeEntity> Types){
    public IEnumerable<PlaneTypeEntity> Types = Types;
}
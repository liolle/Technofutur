using System.ComponentModel.DataAnnotations;
using tf2024_asp_razor.Models.Entities;

namespace tf2024_asp_razor.Models.Plane;

public class FPlaneCreate
{
    // [Required(ErrorMessage = "L'imatriculation est requise")]
    [MinLength(3)]
    public string Imma { get; set; }
    [Required(ErrorMessage = "Le type est requis")]
    public int TypeId { get; set; }
    [Required]
    public int OwnerId { get; set; }

    public PlaneEntity ToEntity()
    {
        return new PlaneEntity()
        {
            Imma = Imma,
            OwnerId = OwnerId,
            TypeId = TypeId
        };
    }
}
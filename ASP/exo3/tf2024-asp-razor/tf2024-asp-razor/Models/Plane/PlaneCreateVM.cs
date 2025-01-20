using tf2024_asp_razor.Models.Entities;

namespace tf2024_asp_razor.Models.Plane;

public class PlaneCreateVM
{
    public FPlaneCreate Form { get; set; }
    public IEnumerable<TaxableEntity> Persons { get; set; }
    public IEnumerable<PlaneTypeEntity> Types { get; set; }
}
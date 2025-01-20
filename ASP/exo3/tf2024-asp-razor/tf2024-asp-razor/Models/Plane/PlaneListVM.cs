using tf2024_asp_razor.Models.Entities;

namespace tf2024_asp_razor.Models.Plane;

public class PlaneListVM(IEnumerable<PlaneEntity> planes)
{
    public IEnumerable<PlaneEntity> Planes { get; set; } = planes;
}
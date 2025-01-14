using System.ComponentModel.DataAnnotations;
using tf2024_asp_razor.Models.Entities.Taxable;

namespace tf2024_asp_razor.Models.Entities;

public class PlaneTypeEntity
{
    [Key] public int Id { get; set; }

    public string Name { get; set; }
    public string Constructor { get; set; }
    public float Power { get; set; }
    public int NbPlace { get; set; }

    public List<PlaneEntity> Planes { get; set; }

    public List<FlightEntity> Flights { get; set; }
    public List<MechanicEntity> Mechanics { get; set; }
}
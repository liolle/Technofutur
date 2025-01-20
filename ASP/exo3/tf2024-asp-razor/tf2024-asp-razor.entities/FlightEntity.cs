using tf2024_asp_razor.Models.Entities.Taxable;

namespace tf2024_asp_razor.Models.Entities;

public class FlightEntity
{
    public int PilotId { get; set; }
    public PilotEntity Pilot { get; set; }

    public int TypeId { get; set; }
    public PlaneTypeEntity Type { get; set; }

    public int NbFlights { get; set; } = 0;
}
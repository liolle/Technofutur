namespace tf2024_asp_razor.Models.Entities.Taxable;

public class PilotEntity : TaxableEntity
{
    public string Licences { get; set; }
    public List<FlightEntity> Flights { get; set; }
}
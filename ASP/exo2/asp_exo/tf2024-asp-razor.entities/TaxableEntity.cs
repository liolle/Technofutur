namespace tf2024_asp_razor.Models.Entities;

public class TaxableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }

    public List<PlaneEntity> Planes { get; set; }
}
using System.ComponentModel.DataAnnotations;
using tf2024_asp_razor.Models.Entities.Taxable;

namespace tf2024_asp_razor.Models.Entities;

public class PlaneEntity
{
    [Key] public int Id { get; set; }

    public string Imma { get; set; }
    public int TypeId { get; set; }
    public PlaneTypeEntity Type { get; set; }

    public int OwnerId { get; set; }
    public   TaxableEntity Owner { get; set; }

    public   IEnumerable<MaintenanceEntity> Maintenances { get; set; }
}
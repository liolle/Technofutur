using tf2024_asp_razor.Models.Entities;

namespace tf2024_asp_razor.Models.Meca;

public class MecaList(IEnumerable<TaxableEntity> mecas)
{
    public IEnumerable<TaxableEntity> mecas { get; set; } = mecas;
}
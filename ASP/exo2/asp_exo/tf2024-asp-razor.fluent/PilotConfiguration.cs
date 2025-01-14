using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tf2024_asp_razor.Models.Entities.Taxable;

namespace tf2024_asp_razor.fluent;

public class PilotConfiguration : IEntityTypeConfiguration<PilotEntity>
{
    public void Configure(EntityTypeBuilder<PilotEntity> builder)
    {
        builder.ToTable("Pilots");
    }
}
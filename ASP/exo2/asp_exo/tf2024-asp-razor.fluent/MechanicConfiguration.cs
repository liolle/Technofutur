using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tf2024_asp_razor.Models.Entities.Taxable;

namespace tf2024_asp_razor.fluent;

public class MechanicConfiguration : IEntityTypeConfiguration<MechanicEntity>
{
    public void Configure(EntityTypeBuilder<MechanicEntity> builder)
    {
        builder.ToTable("Mechanics");

        builder
            .HasMany(m => m.Habilitations)
            .WithMany(t => t.Mechanics);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tf2024_asp_razor.Models.Entities;

namespace tf2024_asp_razor.fluent;

public class FlightConfiguration : IEntityTypeConfiguration<FlightEntity>
{
    public void Configure(EntityTypeBuilder<FlightEntity> builder)
    {
        builder.ToTable("Flight");

        builder.HasKey(f => new { f.PilotId, f.TypeId });

        builder
            .HasOne(f => f.Pilot)
            .WithMany(p => p.Flights)
            .HasForeignKey(p => p.PilotId)
            .OnDelete(DeleteBehavior.NoAction);
        builder
            .HasOne(f => f.Type)
            .WithMany(t => t.Flights)
            .HasForeignKey(f => f.TypeId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
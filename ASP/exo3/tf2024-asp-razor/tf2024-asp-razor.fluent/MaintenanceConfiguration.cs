using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tf2024_asp_razor.Models.Entities.Taxable;

namespace tf2024_asp_razor.fluent;

public class MaintenanceConfiguration : IEntityTypeConfiguration<MaintenanceEntity>
{
    public void Configure(EntityTypeBuilder<MaintenanceEntity> builder)
    {
        builder.ToTable("Maintenance",
            table => { table.HasCheckConstraint("CK_Maintenance_CheckerVerifier", "CheckerId != ReparerId"); });

        builder.Property(m => m.Id).ValueGeneratedOnAdd();
        builder.Property(m => m.Object).IsRequired();
        builder.Property(m => m.PlaneId).IsRequired();
        builder.Property(m => m.Duration).IsRequired();
        builder.Property(m => m.CheckerId).IsRequired();
        builder.Property(m => m.ReparerId).IsRequired();

        builder
            .HasOne(m => m.Plane)
            .WithMany(p => p.Maintenances)
            .HasForeignKey(m => m.PlaneId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(m => m.Reparer)
            .WithMany(r => r.Repared)
            .HasForeignKey(m => m.ReparerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(m => m.Checker)
            .WithMany(c => c.Checked)
            .HasForeignKey(m => m.CheckerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
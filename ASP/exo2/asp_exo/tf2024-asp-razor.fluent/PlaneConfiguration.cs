using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tf2024_asp_razor.Models.Entities;

namespace tf2024_asp_razor.fluent;

public class PlaneConfiguration : IEntityTypeConfiguration<PlaneEntity>
{
    public void Configure(EntityTypeBuilder<PlaneEntity> builder)
    {
        builder.ToTable("Plane");

        builder
            .Property(plane => plane.Id)
            .ValueGeneratedOnAdd();

        builder.Property(plane => plane.TypeId).IsRequired();

        builder
            .Property(plane => plane.Imma)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasOne(plane => plane.Type)
            .WithMany(type => type.Planes)
            .HasForeignKey(plane => plane.TypeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(plane => plane.Owner)
            .WithMany(owner => owner.Planes)
            .HasForeignKey(plane => plane.OwnerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
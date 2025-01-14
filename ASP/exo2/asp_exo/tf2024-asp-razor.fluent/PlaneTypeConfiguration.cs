using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tf2024_asp_razor.Models.Entities;

namespace tf2024_asp_razor.fluent;

public class PlaneTypeConfiguration : IEntityTypeConfiguration<PlaneTypeEntity>
{
    public void Configure(EntityTypeBuilder<PlaneTypeEntity> builder)
    {
        builder.ToTable("PlaneType");
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tf2024_asp_razor.Models.Entities;

namespace tf2024_asp_razor.fluent;

public class TaxableConfiguration : IEntityTypeConfiguration<TaxableEntity>
{
    public void Configure(EntityTypeBuilder<TaxableEntity> builder)
    {
        builder.ToTable("Taxable");
        builder.UseTptMappingStrategy();

        builder.Property(t => t.Id).ValueGeneratedOnAdd();
        builder.Property(t => t.Name).IsRequired();
        builder.Property(t => t.Address).IsRequired();
        builder.Property(t => t.PhoneNumber).IsRequired();
    }
}
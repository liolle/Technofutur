using Microsoft.EntityFrameworkCore;
using tf2024_asp_razor.fluent;
using tf2024_asp_razor.Models.Entities;
using tf2024_asp_razor.Models.Entities.Taxable;

namespace tf2024_asp_razor.Database;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<FlightEntity> Flights { get; set; }
    public DbSet<MaintenanceEntity> Maintenances { get; set; }
    public DbSet<PlaneEntity> Planes { get; set; }
    public DbSet<PlaneTypeEntity> Types { get; set; }
    public DbSet<TaxableEntity> Taxables { get; set; }
    public DbSet<PilotEntity> Pilots { get; set; }
    public DbSet<MechanicEntity> Mechanics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TaxableConfiguration());
        modelBuilder.ApplyConfiguration(new PilotConfiguration());
        modelBuilder.ApplyConfiguration(new MechanicConfiguration());
        modelBuilder.ApplyConfiguration(new PlaneTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PlaneConfiguration());
        modelBuilder.ApplyConfiguration(new MaintenanceConfiguration());
        modelBuilder.ApplyConfiguration(new FlightConfiguration());
    }
}
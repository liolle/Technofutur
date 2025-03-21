using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using tf2024_asp_razor.Models.Entities;
using tf2024_asp_razor.Models.Entities.Taxable;

namespace tf2024_asp_razor.Database;

public interface IDataContext
{
    DbSet<FlightEntity> Flights { get; set; }
    DbSet<MaintenanceEntity> Maintenances { get; set; }
    DbSet<MecanicEntity> Mechanics { get; set; }
    DbSet<PilotEntity> Pilots { get; set; }
    DbSet<PlaneEntity> Planes { get; set; }
    DbSet<TaxableEntity> Taxables { get; set; }
    DbSet<PlaneTypeEntity> Types { get; set; }

    int SaveChanges();
}

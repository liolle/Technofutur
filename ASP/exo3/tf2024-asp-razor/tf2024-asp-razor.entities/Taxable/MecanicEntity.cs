﻿namespace tf2024_asp_razor.Models.Entities.Taxable;

public class MecanicEntity : TaxableEntity
{
    public List<PlaneTypeEntity> Habilitations { get; set; }

    public List<MaintenanceEntity> Repared { get; set; }
    public List<MaintenanceEntity> Checked { get; set; }
}
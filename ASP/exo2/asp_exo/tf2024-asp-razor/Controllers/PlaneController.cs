using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tf2024_asp_razor.Database;
using tf2024_asp_razor.Models.Entities;
using tf2024_asp_razor.Models.Entities.Taxable;
using tf2024_asp_razor.Models.Plane;

namespace tf2024_asp_razor.Controllers;

public class PlaneController(ILogger<PlaneController> logger, DataContext db) : Controller
{
    private static readonly Dictionary<int, PlaneTypeEntity> _planeTypes = new()
    {
        { 1, new PlaneTypeEntity { Id = 1, Name = "A380", NbPlace = 380, Power = 2500 } },
        { 2, new PlaneTypeEntity { Id = 2, Name = "A220", NbPlace = 220, Power = 1250 } }
    };

    private static readonly Dictionary<int, TaxableEntity> _persons = new()
    {
        { 1, new PilotEntity { Id = 1, Name = "Trump", Address = "Mar A Lago", PhoneNumber = "(555) 55 55 55" } },
        {
            2,
            new MechanicEntity { Id = 2, Name = "Biden", Address = "Maison Blanche", PhoneNumber = "(555) 55 55 56" }
        }
    };

    private static readonly List<PlaneEntity> planes = new()
    {
        new PlaneEntity { Id = 42, Imma = "1-BWW-114", TypeId = 1, OwnerId = 2 }
    };

    [Route("/Plane")]
    [Route("/Plane/List")]
    public IActionResult Index()
    {
        return View(new PlaneListVM(db.Planes.Include("Type")));
    }

    public IActionResult Create()
    {
        var model = new PlaneCreateVM();
        model.Form = new FPlaneCreate();
        model.Persons = db.Taxables;
        model.Types = db.Types;

        return View(model);
    }

    [HttpPost]
    public IActionResult Create(FPlaneCreate form)
    {
        if (!ModelState.IsValid)
        {
            var model = new PlaneCreateVM();
            model.Form = form;
            model.Persons = db.Taxables;
            model.Types = db.Types;

            return View(model);
        }

        var plane = form.ToEntity();
        db.Planes.Add(plane);
        db.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        logger.LogInformation($"Delete plane with id: {id}");
        db.Planes.Remove(db.Planes.Find(id));
        return RedirectToAction("Index");
    }
}
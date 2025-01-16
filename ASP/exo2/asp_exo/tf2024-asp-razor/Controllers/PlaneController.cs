using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tf2024_asp_razor.Database;
using tf2024_asp_razor.Models.Plane;

namespace tf2024_asp_razor.Controllers;

public class PlaneController(ILogger<PlaneController> logger, DataContext db) : Controller
{

    [Route("/Plane")]
    public IActionResult Index()
    {
        return View(new PlaneListVM(db.Planes.Include("Type").Include("Owner")));
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
            // send back list of taxable for the new form 
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
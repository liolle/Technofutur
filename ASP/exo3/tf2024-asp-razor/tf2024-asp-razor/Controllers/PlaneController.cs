using AspcoreBll;
using Microsoft.AspNetCore.Mvc;
using tf2024_asp_razor.Models.Plane;

namespace tf2024_asp_razor.Controllers;

public class PlaneController(ILogger<PlaneController> logger ,IPlaneService ps,ITaxableService txs,IPlaneTypeService tps) : Controller
{
   

    public IActionResult Index()
    {
        return View(ps.GetAll());
    }

    public IActionResult Create()
    {
        var model = new PlaneCreateVM();
        model.Form = new FPlaneCreate();
        model.Persons = txs.GetAll();
        model.Types = tps.GetAll();

        return View(model);
    }

    [HttpPost]
    public IActionResult Create(FPlaneCreate form)
    {
        if (!ModelState.IsValid)
        {
            var model = new PlaneCreateVM();
            model.Form = form;
            model.Persons = txs.GetAll();
            model.Types = tps.GetAll();

            return View(model);
        }

        ps.Insert(form.ToEntity());
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        logger.LogInformation($"Delete plane with id: {id}");
        if (ps.Delete(id))
        {
            return RedirectToAction("Index");
        }
        else
        {
            return View();
        }
        
    }
}
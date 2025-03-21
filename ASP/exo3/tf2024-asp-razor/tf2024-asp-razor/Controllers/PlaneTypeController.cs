using AspcoreBll;
using Microsoft.AspNetCore.Mvc;
using tf2024_asp_razor.Models.Plane;

public class PlaneTypeController( IPlaneTypeService pt) : Controller
{
    
    public IActionResult Index()
    {
        return View(pt.GetAll());
    }

    [HttpGet]
    public IActionResult Create(){
        return View();
    }


    [HttpPost]
    public IActionResult Create(PlaneTypeCreate planeType)
    {

        if (!ModelState.IsValid){
            return View(planeType);
        }

        pt.Insert(planeType.ToEntity());
        return RedirectToAction("Index");
    }


    public IActionResult Delete(int id){
        if (pt.Delete(id))
        {
            return RedirectToAction("Index");
        }
        else
        {
            return View();
        }
    }

}
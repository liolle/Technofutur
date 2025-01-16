using Microsoft.AspNetCore.Mvc;
using tf2024_asp_razor.Database;
using tf2024_asp_razor.Models.Entities;
using tf2024_asp_razor.Models.Plane;

public class PlaneTypeController(DataContext db) : Controller
{
    
    [Route("/Plane/types")]
    public IActionResult Index()
    {
        IEnumerable<PlaneTypeEntity> PlaneTypes = db.Types;
        return View(new PlaneTypeList(PlaneTypes));
    }

    [HttpGet]
    public IActionResult Create(){
        return View();
    }


    [HttpPost]
    public IActionResult Create(PlaneTypeCreate planeType)
    {

        if (!ModelState.IsValid){
            Console.WriteLine("invalid");
            return View(planeType);
        }

        db.Types.Add(planeType.ToEntity());
        db.SaveChanges();

        return RedirectToAction("Index");
    }


    public IActionResult Delete(int id){

        PlaneTypeEntity planeType = db.Types.Find(id);
        if (planeType != null){
            db.Types.Remove(planeType);
            db.SaveChanges();
        }

        return RedirectToAction("Index");
    }

}
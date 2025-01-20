using AspcoreBll;
using Microsoft.AspNetCore.Mvc;
using tf2024_asp_razor.Models.Meca;
namespace tf2024_asp_razor.Controllers;

public class MecaController( IMecanicService mcs) : Controller
{

    public IActionResult Index(){
        return View(mcs.GetAll());
    }

    public IActionResult Create(){
        return View();
    }

    [HttpPost]
    public IActionResult Create(MecaCreate meca){
     
        if (!ModelState.IsValid)
        {
            return View(meca);
        }

        mcs.Insert(meca.ToEntity());
        
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id){
        if (mcs.Delete(id))
        {
            return RedirectToAction("Index");
        }
        else
        {
            return View();
        }
    }
}
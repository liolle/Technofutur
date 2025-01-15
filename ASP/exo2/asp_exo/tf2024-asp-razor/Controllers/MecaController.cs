using Microsoft.AspNetCore.Mvc;
using tf2024_asp_razor.Database;
using tf2024_asp_razor.Models.Entities;
using tf2024_asp_razor.Models.Meca;

namespace tf2024_asp_razor.Controllers;

public class MecaController( DataContext db) : Controller
{

    public IActionResult Index(){
        return View(new MecaList(db.Taxables));
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

        TaxableEntity n_meca = meca.ToEntity();
        db.Taxables.Add(n_meca);
        db.SaveChanges();
        
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id){
        TaxableEntity entity = db.Taxables.Find(id);
        if (entity != null){
            db.Taxables.Remove(entity);
            db.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}
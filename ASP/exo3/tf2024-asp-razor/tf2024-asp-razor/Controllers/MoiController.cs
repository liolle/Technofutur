using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using tf2024_asp_razor.Models;

namespace tf2024_asp_razor.Controllers
{
    public class MoiController : Controller
    {
        public static List<Replique> _repliques = new List<Replique>()
            {

                new Replique(){ Film="Starwars", RepliqueCulte= "J'essuie ton père" },
                new Replique(){ Film="La folle histoire de l'espace", RepliqueCulte="Ton astuchse est plus grande que la mienne" },
                new Replique(){ Film="Forest Gump", RepliqueCulte="La vie est comme une boite de chocolat"},
                new Replique(){ Film="Diner de con", RepliqueCulte="Juste le blanc"}

            };
        public MoiController()
        {
             
        }

        public IActionResult Index()
        {
            return View(_repliques);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [RequireAntiforgeryToken]
        public IActionResult Create(Replique toInsert)
        {
            if (ModelState.IsValid)
            {

                _repliques.Add(toInsert);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}

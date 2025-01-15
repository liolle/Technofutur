using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tf2024_asp_razor.Models;
using tf2024_asp_razor.Models.Replique;


namespace tf2024_asp_razor.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Route("")]
    [Route("Home")]
    [Route("Home/Index")]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    [HttpGet]
    [Route("/Moi/RepliqueCulte")]
    public IActionResult Repliques(){
        List<Replique> rep = new(){
            new Replique(){ Film ="Forrest Gump", Phrase = "Life is like a box of chocolates. You never know what you're gonna get."},
            new Replique(){ Film ="Le Parrain", Phrase = "I'm gonna make him an offer he can't refuse."},
            new Replique(){ Film ="Titanic", Phrase = "I'm the king of the world!"},
        };
        return View(new Repliques(rep));
    }
}
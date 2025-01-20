using System.Diagnostics;
using AspcoreBll;
using Microsoft.AspNetCore.Mvc;
using tf2024_asp_razor.Models;

namespace tf2024_asp_razor.Controllers;

public class HomeController(SessionManager session) : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    
}
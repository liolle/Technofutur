using AspcoreBll.Auth;
using Microsoft.AspNetCore.Mvc;
using tf2024_asp_razor.Models.Login;
namespace tf2024_asp_razor.Controllers;
public class AuthController(IAuthService auth) : Controller
{

    public IActionResult Auth(){
        User? user = auth.GetUser();
        if (user == null){
            Console.WriteLine("---");
            return RedirectToAction("Login");
        }

        return RedirectToAction("","Home");
    }
    
    [HttpGet]
    public IActionResult Login(){
        return View();
    }


    [HttpPost]
    public IActionResult Login(LoginForm form){
   
        if (!ModelState.IsValid){
            return View(form);
        }

        if (!auth.Login(form.UserName,form.Password)){
            return View(form);
        }

        return RedirectToAction("","Home");
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TCC_PUC_Tech_Barbershop.Admin.Models;

namespace TCC_PUC_Tech_Barbershop.Admin.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }    
}
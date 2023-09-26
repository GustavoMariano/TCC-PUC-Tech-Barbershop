using Microsoft.AspNetCore.Mvc;

namespace TCC_PUC_Tech_Barbershop.Admin.Controllers;

public class LoginController : Controller
{
    public IActionResult Entrar()
    {
        return View();
    }

    public IActionResult Cadastrar()
    {
        return View();
    }
}

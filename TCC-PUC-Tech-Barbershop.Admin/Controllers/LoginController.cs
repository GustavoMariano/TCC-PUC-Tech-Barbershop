using Microsoft.AspNetCore.Mvc;
using TCC_PUC_Tech_Barbershop.Domain.BarbeiroModule;
using TCC_PUC_Tech_Barbershop.Domain.ClienteModule;

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

    [HttpPost]
    public IActionResult CadastrarCliente(Cliente cliente)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Sucesso");
        }
        return RedirectToAction("Sucesso");
    }

    [HttpPost]
    public IActionResult CadastrarBarbeiro(Barbeiro barbeiro)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Sucesso");
        }
        return RedirectToAction("Sucesso");
    }
}

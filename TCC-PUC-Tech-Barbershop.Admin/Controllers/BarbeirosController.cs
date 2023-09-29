using Microsoft.AspNetCore.Mvc;
using TCC_PUC_Tech_Barbershop.Admin.Models;

namespace TCC_PUC_Tech_Barbershop.Admin.Controllers;

public class BarbeirosController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Visualizar()
    {
        Usuario barbeiro = new Usuario("AA", "AA", null, null, null, TipoUsuarioEnum.Barbeiro);
        barbeiro.AdicionarBarbeiros();
        return View(barbeiro);
    }
}

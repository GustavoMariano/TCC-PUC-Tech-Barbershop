using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_PUC_Tech_Barbershop.Admin.Infra;
using TCC_PUC_Tech_Barbershop.Admin.Models;

namespace TCC_PUC_Tech_Barbershop.Admin.Controllers;

public class UsuarioController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public UsuarioController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult VisualizarPerfil(int? id = null)
    {
        if (id == null)
        {
            int.TryParse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value, out var cookieId);
            id = cookieId;
        }

        Usuario usuario = _dbContext.Usuarios
        .Where(u => u.Id == id)
        .Include(u => u.Informacoes)
        .Include(u => u.Endereco)
        .Include(u => u.Contato)
        .FirstOrDefault();

        return View(usuario);
    }

    public IActionResult EditarPerfil()
    {
        int.TryParse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value, out var cookieId);

        Usuario usuario = _dbContext.Usuarios
        .Where(u => u.Id == cookieId)
        .Include(u => u.Informacoes)
        .Include(u => u.Endereco)
        .Include(u => u.Contato)
        .FirstOrDefault();

        return View(usuario);
    }

    public IActionResult Editar()
    {
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Deletar()
    {
        return RedirectToAction("Index", "Home");
    }
}

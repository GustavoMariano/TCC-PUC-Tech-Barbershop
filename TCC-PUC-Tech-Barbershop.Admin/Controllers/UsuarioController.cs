using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
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

    public IActionResult VisualizarPerfil()
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
}

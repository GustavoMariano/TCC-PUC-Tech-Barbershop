using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_PUC_Tech_Barbershop.Admin.Infra;
using TCC_PUC_Tech_Barbershop.Admin.Models;

namespace TCC_PUC_Tech_Barbershop.Admin.Controllers;

public class BarbeirosController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public BarbeirosController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Visualizar()
    {
        List<Usuario> barbeiros = _dbContext.Usuarios
        .Where(u => u.TipoUsuario == TipoUsuarioEnum.Barbeiro)
        .Include(u => u.Informacoes)
        .Include(u => u.Endereco)
        .Include(u => u.Contato)
        .ToList();

        Usuario usuario = new();

        if (barbeiros.Count() > 0)
            usuario.Usuarios = barbeiros;

        return View(usuario);
    }

    [HttpGet]
    public IActionResult SelecionarPorId(int id)
    {
        var barbeiro = _dbContext.Usuarios
            .Include(u => u.Informacoes)
            .Include(u => u.Endereco)
            .Include(u => u.Contato)
            .FirstOrDefault(u => u.Id == id);

        return PartialView("_DetalhesPerfil", barbeiro);
    }

    [HttpPost]
    public IActionResult FiltrarBarbeiros(string barbeiroName)
    {
        List<Usuario> barbeiros = _dbContext.Usuarios
        .Where(u => u.TipoUsuario == TipoUsuarioEnum.Barbeiro)
        .Where(u => u.Informacoes.Nome.Contains(barbeiroName))
        .Include(u => u.Informacoes)
        .Include(u => u.Endereco)
        .Include(u => u.Contato)
        .ToList();

        Usuario usuario = new();

        if (barbeiros.Count() > 0)
            usuario.Usuarios = barbeiros;

        return View("Visualizar", usuario);
    }
}

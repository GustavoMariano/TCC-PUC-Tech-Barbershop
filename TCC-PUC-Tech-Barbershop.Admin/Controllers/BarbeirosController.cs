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

        if (barbeiros != null)
            usuario.Usuarios = barbeiros;

        return View(usuario);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_PUC_Tech_Barbershop.Admin.Infra;
using TCC_PUC_Tech_Barbershop.Admin.Models;

namespace TCC_PUC_Tech_Barbershop.Admin.Controllers;

public class AtendimentoController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public AtendimentoController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Agendamento()
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

    public IActionResult Historico()
    {
        Usuario atendimento = new(0, "AA", "AA", null, null, null, TipoUsuarioEnum.Cliente);
        atendimento.AdicionarAtendimentos();
        return View(atendimento);
    }


    [HttpPost]
    public async Task<ActionResult<dynamic>> CadastrarAtendimento(Atendimento model)
    {
        // Verifique aqui se o model está corretamente preenchido com os dados do formulário.
        var a = model.Barbeiro.Id;
        // Retorna os dados
        return RedirectToAction("Index", "Home");
    }
}

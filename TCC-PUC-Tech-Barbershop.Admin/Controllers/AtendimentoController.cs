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

    public IActionResult Agendar(int? barbeiroId = null)
    {
        if (barbeiroId == null)
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
        else
        {
            var barbeiro = _dbContext.Usuarios
            .Include(u => u.Informacoes)
            .Include(u => u.Endereco)
            .Include(u => u.Contato)
            .FirstOrDefault(u => u.Id == barbeiroId);

            if (barbeiro == null || barbeiro.TipoUsuario != TipoUsuarioEnum.Barbeiro)
                return NotFound();

            // Passe os dados do barbeiro para a página de agendamento
            ViewBag.BarbeiroId = barbeiro.Id;
            ViewBag.BarbeiroInfos = $"{barbeiro.Informacoes.Nome} " +
                $"{barbeiro.Informacoes.Sobrenome} - " +
                $"{barbeiro.Contato.Celular} - " +
                $"{barbeiro.Endereco.Cidade} / " +
                $"{barbeiro.Endereco.Estado}, " +
                $"{barbeiro.Endereco.Bairro}";

            return View();
        }
    }

    public IActionResult Atendimentos()
    {
        Usuario atendimento = new(0, "AA", "AA", null, null, null, TipoUsuarioEnum.Cliente);
        atendimento.AdicionarAtendimentos();
        return View(atendimento);
    }


    [HttpPost]
    public async Task<ActionResult<dynamic>> CadastrarAtendimento(Atendimento model)
    {
        if(model.BarbeiroId != 0)
        {
            //Implementação
        }
        // Retorna os dados
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<ActionResult<dynamic>> CancelarAtendimento(int atendimentoId)
    {
        try
        {
            var atendimento = await _dbContext.Atendimentos.FindAsync(atendimentoId);

            if (atendimento != null)
            {
                _dbContext.Atendimentos.Remove(atendimento);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}

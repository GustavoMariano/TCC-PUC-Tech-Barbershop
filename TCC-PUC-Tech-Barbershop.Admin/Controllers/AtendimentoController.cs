using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
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
        if (barbeiroId == null && User.HasClaim(ClaimTypes.Role, "Cliente"))
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
        else if (User.HasClaim(ClaimTypes.Role, "Barbeiro"))
        {
            List<Usuario> barbeiros = _dbContext.Usuarios
            .Where(u => u.TipoUsuario == TipoUsuarioEnum.Cliente)
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
        int.TryParse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value, out var cookieId);

        if (User.HasClaim(ClaimTypes.Role, "Cliente"))
        {
            List<Atendimento> atendimentos = _dbContext.Atendimentos
            .Where(a => a.ClienteId == cookieId)
            .Include(u => u.Cliente)
                .ThenInclude(c => c.Informacoes)
            .Include(u => u.Cliente)
                .ThenInclude(c => c.Endereco)
            .Include(u => u.Cliente)
                .ThenInclude(c => c.Contato)

            .Include(u => u.Barbeiro)
                .ThenInclude(b => b.Informacoes)
            .Include(u => u.Barbeiro)
                .ThenInclude(b => b.Endereco)
            .Include(u => u.Barbeiro)
                .ThenInclude(b => b.Contato)
            .ToList();

            Usuario result = new();

            if (atendimentos.Count() > 0)
                result.Atendimentos = atendimentos;

            return View(result);
        }
        else
        {
            List<Atendimento> atendimentos = _dbContext.Atendimentos
            .Where(a => a.BarbeiroId == cookieId)
            .Include(u => u.Cliente)
                .ThenInclude(c => c.Informacoes)
            .Include(u => u.Cliente)
                .ThenInclude(c => c.Endereco)
            .Include(u => u.Cliente)
                .ThenInclude(c => c.Contato)

            .Include(u => u.Barbeiro)
                .ThenInclude(b => b.Informacoes)
            .Include(u => u.Barbeiro)
                .ThenInclude(b => b.Endereco)
            .Include(u => u.Barbeiro)
                .ThenInclude(b => b.Contato)
            .ToList();

            Usuario result = new();

            if (atendimentos.Count() > 0)
                result.Atendimentos = atendimentos;

            return View(result);
        }
    }

    public IActionResult EditarAtendimento(int AtendimentoId)
    {
        Usuario usuario = new Usuario();

        usuario.Atendimento = _dbContext.Atendimentos
        .Where(u => u.Id == AtendimentoId)
        .Include(u => u.Cliente)
            .ThenInclude(c => c.Informacoes)
        .Include(u => u.Cliente)
            .ThenInclude(c => c.Endereco)
        .Include(u => u.Cliente)
            .ThenInclude(c => c.Contato)
        .Include(u => u.Barbeiro)
            .ThenInclude(b => b.Informacoes)
        .Include(u => u.Cliente)
            .ThenInclude(b => b.Endereco)
        .Include(u => u.Cliente)
            .ThenInclude(b => b.Contato)
        .FirstOrDefault();

        if (User.HasClaim(ClaimTypes.Role, "Cliente"))
        {
            List<Usuario> barbeiros = _dbContext.Usuarios
            .Where(u => u.TipoUsuario == TipoUsuarioEnum.Barbeiro)
            .Include(u => u.Informacoes)
            .Include(u => u.Endereco)
            .Include(u => u.Contato)
            .ToList();

            if (barbeiros.Count() > 0)
                usuario.Usuarios = barbeiros;

            return View(usuario);
        }
        else
        {
            List<Usuario> barbeiros = _dbContext.Usuarios
            .Where(u => u.TipoUsuario == TipoUsuarioEnum.Cliente)
            .Include(u => u.Informacoes)
            .Include(u => u.Endereco)
            .Include(u => u.Contato)
            .ToList();

            if (barbeiros.Count() > 0)
                usuario.Usuarios = barbeiros;

            return View(usuario);
        }
    }

    [HttpPost]
    public async Task<ActionResult<dynamic>> CadastrarAtendimento(Atendimento model)
    {
        int.TryParse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value, out var cookieId);

        if (model.BarbeiroId != 0)
        {
            model.ClienteId = cookieId;
        }
        else if (model.ClienteId != 0)
        {
            model.BarbeiroId = cookieId;
        }

        _dbContext.Atendimentos.Add(model);

        await _dbContext.SaveChangesAsync();

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<ActionResult<dynamic>> Editar(Atendimento model)
    {
        try
        {
            var atendimentoExistente = await _dbContext.Atendimentos.FindAsync(model.Id);

            if (atendimentoExistente != null)
            {

                if(User.HasClaim(ClaimTypes.Role, "Cliente"))
                    atendimentoExistente.BarbeiroId = model.BarbeiroId;
                else
                    atendimentoExistente.ClienteId = model.ClienteId;
                atendimentoExistente.DataHora = model.DataHora;

                _dbContext.Update(atendimentoExistente);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return NotFound();
            }
        }
        catch (DbUpdateException ex)
        {
            ModelState.AddModelError("", "Erro ao atualizar o atendimento.");
            return View(model);
        }
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

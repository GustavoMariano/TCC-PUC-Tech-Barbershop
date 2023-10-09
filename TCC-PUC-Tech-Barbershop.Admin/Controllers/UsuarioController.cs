using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        if (id == null || id == 0)
        {
            int.TryParse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value, out var cookieId);
            id = cookieId;

            if (id == null || id == 0)
                return RedirectToAction("Index", "Home");

             Usuario usuario = _dbContext.Usuarios
            .Where(u => u.Id == id)
            .Include(u => u.Informacoes)
            .Include(u => u.Endereco)
            .Include(u => u.Contato)
            .FirstOrDefault();

            if (usuario.TipoUsuario == TipoUsuarioEnum.Barbeiro)
            {
                usuario.Atendimentos = _dbContext.Atendimentos
               .Where(a => a.BarbeiroId == usuario.Id)
               .ToList();

                usuario.Comentarios = _dbContext.Comentarios
                .Where(a => a.BarbeiroId == usuario.Id)
                .Include(u => u.Cliente)
                .ThenInclude(c => c.Informacoes)
                .ToList();
            }

            return View(usuario);
        }
        else
        {
            Usuario usuario = _dbContext.Usuarios
            .Where(u => u.Id == id)
            .Include(u => u.Informacoes)
            .Include(u => u.Endereco)
            .Include(u => u.Contato)
            .FirstOrDefault();

            if (usuario.TipoUsuario == TipoUsuarioEnum.Barbeiro)
            {
                usuario.Atendimentos = _dbContext.Atendimentos
               .Where(a => a.BarbeiroId == usuario.Id)
               .ToList();

                usuario.Comentarios = _dbContext.Comentarios
                .Where(a => a.BarbeiroId == usuario.Id)
                .Include(u => u.Cliente)
                .ThenInclude(c => c.Informacoes)
                .ToList();
            }

            return View(usuario);
        }
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

    public async Task<IActionResult> Editar(Usuario usuario, IFormFile Imagem)
    {
        int.TryParse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value, out var cookieId);

        try
        {
            var usuarioExistente = await _dbContext.Usuarios.FindAsync(cookieId);

            if (usuarioExistente != null)
            {
                usuarioExistente.Contato = usuario.Contato;
                usuarioExistente.Informacoes = usuario.Informacoes;
                usuarioExistente.Endereco = usuario.Endereco;

                if (!string.IsNullOrEmpty(usuario.Senha))
                    usuarioExistente.Senha = usuario.Senha;

                if (!string.IsNullOrEmpty(usuario.FormasPagamentos))
                    usuarioExistente.FormasPagamentos = usuario.FormasPagamentos;

                if (Imagem != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        Imagem.CopyTo(ms);
                        usuarioExistente.Imagem = ms.ToArray();
                    }
                }

                _dbContext.Update(usuarioExistente);
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
            ModelState.AddModelError("", "Erro ao atualizar o usuário.");
            return View(usuario);
        }
    }

    public async Task<IActionResult> ComentarAsync(string Texto, int BarbeiroId)
    {
        int.TryParse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value, out var cookieId);
        Comentario comentario = new Comentario() { BarbeiroId = BarbeiroId, ClienteId = cookieId, Texto = Texto };

        _dbContext.Comentarios.Add(comentario);

        await _dbContext.SaveChangesAsync();

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> DeletarAsync()
    {
        try
        {
            int.TryParse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value, out var cookieId);

            var usuario = _dbContext.Usuarios
            .Where(u => u.Id == cookieId)
            .Include(u => u.Informacoes)
            .Include(u => u.Endereco)
            .Include(u => u.Contato)
            .FirstOrDefault();

            if (usuario.TipoUsuario == TipoUsuarioEnum.Barbeiro)
            {
                usuario.Atendimentos = _dbContext.Atendimentos
                   .Where(a => a.BarbeiroId == usuario.Id)
                   .ToList();

                usuario.Comentarios = _dbContext.Comentarios
                .Where(a => a.BarbeiroId == usuario.Id)
                .Include(u => u.Cliente)
                .ThenInclude(c => c.Informacoes)
                .ToList();
            }
            else
            {
                usuario.Atendimentos = _dbContext.Atendimentos
                   .Where(a => a.ClienteId == usuario.Id)
                   .ToList();

                usuario.Comentarios = _dbContext.Comentarios
                .Where(a => a.ClienteId == usuario.Id)
                .Include(u => u.Cliente)
                .ThenInclude(c => c.Informacoes)
                .ToList();
            }

            foreach (var atendimento in usuario.Atendimentos.ToList())
            {
                _dbContext.Atendimentos.Remove(atendimento);
            }

            foreach (var comentario in usuario.Comentarios.ToList())
            {
                _dbContext.Comentarios.Remove(comentario);
            }

            if (usuario != null)
            {
                _dbContext.Usuarios.Remove(usuario);
                await _dbContext.SaveChangesAsync();
            }

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}

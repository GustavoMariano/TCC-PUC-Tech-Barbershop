using Microsoft.AspNetCore.Mvc;
using TCC_PUC_Tech_Barbershop.Admin.Models;
using TCC_PUC_Tech_Barbershop.Admin.Repositories;
using TCC_PUC_Tech_Barbershop.Admin.Services;

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

    [Route("Login/Autenticar")]
    [HttpPost]
    public async Task<ActionResult<dynamic>> Autenticar(Usuario model)
    {
        // Recupera o usuário
        var user = UsuarioRepository.Get(model.Login, model.Senha);

        // Verifica se o usuário existe
        if (user == null)
            return NotFound(new { message = "Usuário ou senha inválidos" });

        // Gera o Token
        var token = TokenService.GenerateToken(user);

        // Oculta a senha
        user.Senha = "";

        // Retorna os dados
        return new
        {
            user = user,
            token = token
        };
    }

    public IActionResult LoginCliente(Cliente cliente)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Sucesso");
        }
        return RedirectToAction("Sucesso");
    }

    [HttpPost]
    public IActionResult LoginBarbeiro(Barbeiro barbeiro)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Sucesso");
        }
        return RedirectToAction("Sucesso");
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

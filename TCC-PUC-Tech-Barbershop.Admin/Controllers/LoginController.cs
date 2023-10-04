using Microsoft.AspNetCore.Mvc;
using TCC_PUC_Tech_Barbershop.Admin.Infra;
using TCC_PUC_Tech_Barbershop.Admin.Models;
using TCC_PUC_Tech_Barbershop.Admin.Repositories;
using TCC_PUC_Tech_Barbershop.Admin.Services;

namespace TCC_PUC_Tech_Barbershop.Admin.Controllers;

public class LoginController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    public LoginController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

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
        {
            TempData["ErrorMessage"] = "Usuário ou senha inválidos";
            return RedirectToAction("Entrar", "Login");
        }

        // Gera o Token
        var token = TokenService.GenerateToken(user);

        // Oculta a senha
        user.Senha = "";

        // Retorna os dados
        return RedirectToAction("Index", "Home");
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
    public IActionResult CadastrarUsuario(Usuario cliente)
    {
        Usuario novoRegistro;
        if (cliente.TipoUsuario == TipoUsuarioEnum.Cliente)
        {
            novoRegistro = new Cliente()
            {
                Login = cliente.Login,
                Senha = cliente.Senha,
                Contato = cliente.Contato,
                Informacoes = cliente.Informacoes,
                Endereco = cliente.Endereco,
                TipoUsuario = cliente.TipoUsuario
            };
        }
        else
        {
            novoRegistro = new Barbeiro()
            {
                Login = cliente.Login,
                Senha = cliente.Senha,
                Contato = cliente.Contato,
                Informacoes = cliente.Informacoes,
                Endereco = cliente.Endereco,
                TipoUsuario = cliente.TipoUsuario
            };
        }

        _dbContext.Usuarios.Add(novoRegistro);
        _dbContext.SaveChanges();

        return RedirectToAction("Entrar", "Login");
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

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TCC_PUC_Tech_Barbershop.Admin.Infra;
using TCC_PUC_Tech_Barbershop.Admin.Models;

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

    [HttpPost]
    public IActionResult LoginUsuario(Usuario usuario)
    {
        var user = _dbContext.Usuarios.Include(u => u.Informacoes).FirstOrDefault(u => u.Login == usuario.Login && u.Senha == usuario.Senha);

        if (user != null)
        {
            bool result = HttpContext.User.Identity.IsAuthenticated;
            List<Claim> claims = new() {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Informacoes.Nome),
                new Claim(ClaimTypes.Role, user.TipoUsuario.ToString())
                };
            var identity = new ClaimsIdentity(claims.ToArray(), CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTime.Now.AddHours(1),
                IssuedUtc = DateTime.Now
            };            

            var principal = new ClaimsPrincipal(identity);
            HttpContext.User = principal;
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

            return RedirectToAction("Index", "Home");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Credenciais inválidas. Verifique seu login e senha.");

            return View("Entrar", usuario);
        }
    }

    [HttpPost]
    public IActionResult CadastrarUsuario(Usuario cliente, IFormFile Imagem)
    {
        var existingUser = _dbContext.Usuarios.FirstOrDefault(u => u.Login == cliente.Login);

        if (existingUser != null)
        {
            ModelState.AddModelError(string.Empty, "Login já está sendo usado, tente outro.");
            return View("Cadastrar", existingUser);
        }

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

        if (Imagem != null)
        {
            using (var ms = new MemoryStream())
            {
                Imagem.CopyTo(ms);
                novoRegistro.Imagem = ms.ToArray();
            }
        }
        else
        {
            string imagePath = Path.Combine($"{Directory.GetCurrentDirectory()}/wwwroot/img/semFoto.png");

            using (FileStream fs = new FileStream(imagePath, FileMode.Open))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    novoRegistro.Imagem = ms.ToArray();
                }
            }
        }

        _dbContext.Usuarios.Add(novoRegistro);
        _dbContext.SaveChanges();

        return RedirectToAction("Entrar", "Login");
    }

    public IActionResult Sair()
    {
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Index", "Home");
    }
}

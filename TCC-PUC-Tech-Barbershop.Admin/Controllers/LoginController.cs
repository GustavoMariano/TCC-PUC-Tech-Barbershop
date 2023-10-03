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
    public IActionResult CadastrarCliente(Usuario cliente)
    {
        if (ModelState.IsValid)
        {

            // Crie um objeto para o registro e preencha com os dados do modelo
            var novoRegistro = new Cliente
            {
                // Preencha as propriedades com base nos campos do modelo
                Login = cliente.Login,
                Senha = cliente.Senha,
                Contato = cliente.Contato,
                Informacoes = cliente.Informacoes,
                Endereco = cliente.Endereco,
                TipoUsuario = cliente.TipoUsuario
                // Preencha outras propriedades aqui...
            };

            // Adicione o novo registro ao DbContext
            _dbContext.Usuarios.Add(novoRegistro);

            // Salve as alterações no banco de dados
            _dbContext.SaveChanges();

            // Redirecione para uma página de sucesso ou outra página apropriada
            return RedirectToAction("Sucesso");
        }

        // Se o modelo não for válido, retorne a página de formulário com erros
        return View(cliente);
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

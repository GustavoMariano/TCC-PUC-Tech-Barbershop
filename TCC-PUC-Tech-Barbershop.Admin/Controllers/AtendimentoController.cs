﻿using Microsoft.AspNetCore.Mvc;
using TCC_PUC_Tech_Barbershop.Admin.Models;

namespace TCC_PUC_Tech_Barbershop.Admin.Controllers;

public class AtendimentoController : Controller
{
    public IActionResult Agendamento()
    {
        Usuario barbeiro = new Usuario(0, "AA", "AA", null, null, null, TipoUsuarioEnum.Barbeiro);
        barbeiro.AdicionarBarbeiros();
        return View(barbeiro);
    }

    [HttpPost]
    public async Task<ActionResult<dynamic>> CadastrarAtendimento(Atendimento model)
    {
        // Verifique aqui se o model está corretamente preenchido com os dados do formulário.
        var a = model.IdBarbeiro;
        // Retorna os dados
        return RedirectToAction("Index", "Home");
    }
}

using System.ComponentModel.DataAnnotations;

namespace TCC_PUC_Tech_Barbershop.Admin.Models;

public class Contato
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Campo obrigatório.")]
    public string Celular { get; set; }
    [Required(ErrorMessage = "Campo obrigatório.")]
    public string Email { get; set; }

    public Contato(string celular, string email)
    {
        Celular = celular;
        Email = email;
    }

    public Contato()
    {
    }
}

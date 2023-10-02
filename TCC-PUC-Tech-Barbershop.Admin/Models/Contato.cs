namespace TCC_PUC_Tech_Barbershop.Admin.Models;

public class Contato
{
    public int Id { get; set; }
    public string Celular { get; set; }
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

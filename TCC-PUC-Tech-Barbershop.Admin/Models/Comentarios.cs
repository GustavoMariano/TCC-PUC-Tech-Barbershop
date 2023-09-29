namespace TCC_PUC_Tech_Barbershop.Admin.Models;

public class Comentarios
{
    public int Id { get; set; }
    public string Texto { get; set; }
    public int IdCliente { get; set; }
    public int IdBarbeiro { get; set; }
}

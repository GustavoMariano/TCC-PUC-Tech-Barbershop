namespace TCC_PUC_Tech_Barbershop.Admin.Models;

public class Atendimento
{
    public int Id { get; set; }
    public string Data { get; set; }
    public string Hora { get; set; }
    public int IdCliente{ get; set; }
    public int IdBarbeiro { get; set; }
}

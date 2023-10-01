namespace TCC_PUC_Tech_Barbershop.Admin.Models;

public class Atendimento
{
    public int Id { get; set; }
    public string Data { get; set; }
    public string Hora { get; set; }
    public int ClienteId { get; set; }
    public int BarbeiroId { get; set; }
    public Cliente Cliente{ get; set; }
    public Barbeiro Barbeiro { get; set; }

    public Atendimento()
    {
    }
}

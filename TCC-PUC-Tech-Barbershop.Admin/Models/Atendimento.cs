namespace TCC_PUC_Tech_Barbershop.Admin.Models;

public class Atendimento
{
    public int Id { get; set; }
    public string Data { get; set; }
    public string Hora { get; set; }
    public int ClienteId { get; set; }
    public int BarbeiroId { get; set; }
    public Usuario Cliente { get; set; }
    public Usuario Barbeiro { get; set; }

    public Atendimento()
    {
    }

    public Atendimento(string data, string hora, int clienteId, int barbeiroId, Usuario cliente, Usuario barbeiro)
    {
        Data = data;
        Hora = hora;
        ClienteId = clienteId;
        BarbeiroId = barbeiroId;
        Cliente = cliente;
        Barbeiro = barbeiro;
    }
}

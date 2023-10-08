using System.ComponentModel.DataAnnotations.Schema;

namespace TCC_PUC_Tech_Barbershop.Admin.Models;

public class Atendimento
{
    public int Id { get; set; }
    
    public int ClienteId { get; set; }
    public int BarbeiroId { get; set; }
    public Usuario Cliente { get; set; }
    public Usuario Barbeiro { get; set; }
    public DateTime DataHora { get; set; }
    public List<Atendimento> Atendimentos { get; set; }
    public Atendimento()
    {
    }

    public Atendimento(int id, DateTime datahora, int clienteId, int barbeiroId, Usuario cliente, Usuario barbeiro)
    {
        Id = id;
        DataHora = datahora;
        ClienteId = clienteId;
        BarbeiroId = barbeiroId;
        Cliente = cliente;
        Barbeiro = barbeiro;
    }
}

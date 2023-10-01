namespace TCC_PUC_Tech_Barbershop.Admin.Models;

public class Comentario
{
    public int Id { get; set; }
    public string Texto { get; set; }
    public int ClienteId { get; internal set; }
    public int BarbeiroId { get; internal set; }
    public Cliente Cliente { get; set; }
    public Barbeiro Barbeiro { get; set; }    

    public Comentario()
    {
    }
}

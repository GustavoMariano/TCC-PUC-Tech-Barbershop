namespace TCC_PUC_Tech_Barbershop.Domain.AtendimentoModule;

public class Atendimento
{
    public int Id { get; set; }
    public DateTime DataHora { get; set; }
    public int IdCliente{ get; set; }
    public int IdBarbeiro { get; set; }
}

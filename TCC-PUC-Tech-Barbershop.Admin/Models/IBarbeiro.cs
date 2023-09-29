namespace TCC_PUC_Tech_Barbershop.Admin.Models
{
    public interface IBarbeiro
    {
        Agenda Agenda { get; set; }
        List<Atendimento> Atendimentos { get; set; }
        FormasPagamento FormasAceitas { get; set; }
    }
}
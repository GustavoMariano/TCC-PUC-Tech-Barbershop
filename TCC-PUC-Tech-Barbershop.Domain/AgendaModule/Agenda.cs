namespace TCC_PUC_Tech_Barbershop.Domain.AgendaModule;

public class Agenda
{
    public int Id { get; set; }
    List<DateOnly> DatasDisponiveis { get; set; }
    List<TimeOnly> HorasDisponiveis { get; set; }
}

namespace TCC_PUC_Tech_Barbershop.Admin.Models;

public class Agenda
{
    public int Id { get; set; }
    List<DateOnly> DatasDisponiveis { get; set; }
    List<TimeOnly> HorasDisponiveis { get; set; }
}

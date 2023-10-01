using System.ComponentModel.DataAnnotations.Schema;

namespace TCC_PUC_Tech_Barbershop.Admin.Models;

public class Agenda
{
    public int Id { get; set; }
    public string Data { get; set; }
    public string Hora { get; set; }
    [NotMapped]
    List<DateOnly> DatasDisponiveis { get; set; }
    [NotMapped]
    List<TimeOnly> HorasDisponiveis { get; set; }

    public Agenda()
    {
    }
}

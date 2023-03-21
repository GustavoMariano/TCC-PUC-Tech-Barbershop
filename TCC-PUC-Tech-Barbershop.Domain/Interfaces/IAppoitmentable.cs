using TCC_PUC_Tech_Barbershop.Domain.Models;

namespace TCC_PUC_Tech_Barbershop.Domain.Interfaces;

public interface IAppoitmentable : IRepository<AppointmentModel>
{
    bool VerifyDisponibility(AppointmentModel schedule);
    List<AppointmentModel> SelectByDay(DateTime date);
    bool UpdateStatus(int id, bool isActive);
}

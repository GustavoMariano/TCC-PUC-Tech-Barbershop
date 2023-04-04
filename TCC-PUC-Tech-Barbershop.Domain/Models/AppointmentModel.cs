using TCC_PUC_Tech_Barbershop.Domain.Shared;

namespace TCC_PUC_Tech_Barbershop.Domain.Models;

public class AppointmentModel : BaseEntity
{
    public BarberModel Barber { get; set; }
    public CustomerModel Customer { get; set; }
    public DateOnly AppointmentDate { get; set; }

    public AppointmentModel()
    {
    }

    public AppointmentModel(int id, BarberModel barber, CustomerModel customer, DateOnly appointmentDate)
    {
        Id = id;
        Barber = barber;
        Customer = customer;
        AppointmentDate = appointmentDate;
    }

    public override string Validate()
    {
        string result = "";

        if (Barber == null)
            result = "It is not possible to schedule a job without a barber.\n";
        if (result == "")
            result = "VALID";

        return result;
    }

    public override string ToString()
    {
        string customerName = "";
        if (Customer != null)
            customerName = Customer.Name;

        return $"{Barber.Name} {customerName} {AppointmentDate}";
    }

    public override bool Equals(object obj)
    {
        return obj is AppointmentModel schedule &&
        Id == schedule.Id &&
               EqualityComparer<BarberModel>.Default.Equals(Barber, schedule.Barber) &&
               EqualityComparer<CustomerModel>.Default.Equals(Customer, schedule.Customer) &&
               AppointmentDate == schedule.AppointmentDate;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Barber, Customer, AppointmentDate);
    }
}

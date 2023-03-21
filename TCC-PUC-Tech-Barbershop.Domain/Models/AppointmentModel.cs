using TCC_PUC_Tech_Barbershop.Domain.Shared;

namespace TCC_PUC_Tech_Barbershop.Domain.Models;

public class AppointmentModel : BaseEntity
{
    public BarberModel Barber { get; set; }
    public CustomerModel Customer { get; set; }
    public List<ServiceModel> Services { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime FinishTime { get; set; }
    public Double Price { get; set; }
    public bool IsActive { get; set; }

    public AppointmentModel()
    {
    }

    public AppointmentModel(int id, BarberModel barber, CustomerModel customer, List<ServiceModel> services, DateTime startTime, DateTime finishTime, double price, bool isActive)
    {
        Id = id;
        Barber = barber;
        Customer = customer;
        Services = services;
        StartTime = startTime;
        FinishTime = finishTime;
        Price = price;
        IsActive = isActive;
    }

    public override string Validate()
    {
        string result = "";

        if (Barber == null)
            result = "It is not possible to schedule a job without a barber.\n";
        if (StartTime == DateTime.MinValue)
            result += "Select a date and time to schedule the job.";
        if (FinishTime == DateTime.MinValue)
            result += "Insert a total time to this job.";
        if (result == "")
            result = "VALID";

        return result;
    }

    public override string ToString()
    {
        string customerName = "";
        if (Customer != null)
            customerName = Customer.Name;

        return $"{Barber.Name} {customerName} {StartTime}";
    }

    public override bool Equals(object obj)
    {
        return obj is AppointmentModel schedule &&
        Id == schedule.Id &&
               EqualityComparer<BarberModel>.Default.Equals(Barber, schedule.Barber) &&
               EqualityComparer<CustomerModel>.Default.Equals(Customer, schedule.Customer) &&
               EqualityComparer<List<ServiceModel>>.Default.Equals(Services, schedule.Services) &&
               StartTime == schedule.StartTime &&
               FinishTime == schedule.FinishTime &&
               Price == schedule.Price &&
               IsActive == schedule.IsActive;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Barber, Customer, Services, StartTime, FinishTime, Price, IsActive);
    }
}

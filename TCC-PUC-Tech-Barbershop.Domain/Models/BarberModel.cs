using TCC_PUC_Tech_Barbershop.Domain.Enums;
using TCC_PUC_Tech_Barbershop.Domain.Shared;

namespace TCC_PUC_Tech_Barbershop.Domain.Models;

public class BarberModel : PersonModule
{
    public string Phone { get; set; }
    public string Email { get; set; }
    public EBarber BarberLevel { get; set; }
    public List<AppointmentModel> Appointments { get; set; }

    public BarberModel()
    {        
    }

    public BarberModel(int id, string name, string phone, string email, EBarber barberLevel)
    {
        Id = id;
        Name = name;
        Phone = phone;
        Email = email;
        BarberLevel = barberLevel;
    }

    public override string Validate()
    {
        string result = "";

        if (Phone.Length == 0 || Phone.Length > 20)
            result += "Insert a cell phone number valid";
        result += ValidatePerson();
        if (result == "")
            result = "VALID";

        return result;
    }

    public override string ToString()
    {
        return Name;
    }

    public override bool Equals(object obj)
    {
        return obj is BarberModel barber &&
               Id == barber.Id &&
               Name == barber.Name &&
               Phone == barber.Phone &&
               Email == barber.Email &&
               BarberLevel == barber.BarberLevel;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Phone, Email, BarberLevel);
    }
}

using TCC_PUC_Tech_Barbershop.Domain.Shared;

namespace TCC_PUC_Tech_Barbershop.Domain.Models;

public class BarberModel : PersonModule
{
    public string Phone { get; set; }
    public DateTime Birthday { get; set; }
    public DateTime AdmissionDate { get; set; }
    public List<AppointmentModel> Appointments { get; set; }

    public BarberModel(int id, string name, string phone, DateTime birthday, DateTime admissionDate)
    {
        Id = id;
        Name = name;
        Phone = phone;
        Birthday = birthday;
        AdmissionDate = admissionDate;
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
               Birthday == barber.Birthday &&
               AdmissionDate == barber.AdmissionDate;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Phone, Birthday, AdmissionDate);
    }
}

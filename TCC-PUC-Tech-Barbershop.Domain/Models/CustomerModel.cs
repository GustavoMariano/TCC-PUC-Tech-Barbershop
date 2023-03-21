using TCC_PUC_Tech_Barbershop.Domain.Shared;

namespace TCC_PUC_Tech_Barbershop.Domain.Models;

public class CustomerModel : PersonModule
{
    public string Phone { get; set; }
    public List<AppointmentModel> Appointments { get; set; }

    public CustomerModel(int id, string name, string phone)
    {
        Id = id;
        Name = name;
        Phone = phone;
    }

    public override string Validate()
    {
        string result = "";

        result += ValidatePerson();
        if (result == "" || result == "VALID")
            result = "VALID";

        return result;
    }

    public override string ToString()
    {
        return Name;
    }

    public override bool Equals(object obj)
    {
        return obj is CustomerModel customer &&
               Id == customer.Id &&
               Name == customer.Name &&
               Phone == customer.Phone;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Phone);
    }
}

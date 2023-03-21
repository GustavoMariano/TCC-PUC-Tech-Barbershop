using TCC_PUC_Tech_Barbershop.Domain.Shared;

namespace TCC_PUC_Tech_Barbershop.Domain.Models;

public class ServiceModel : BaseEntity
{
    // ENUM public string Type { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public List<AppointmentModel> Appointments { get; set; }

    public ServiceModel(int id, string name, double price)
    {
        this.Id = id;
        this.Name = name;
        this.Price = price;
    }

    public override string Validate()
    {
        string result = "";

        if (string.IsNullOrEmpty(Name))
            result += "The name field cannot be null;\n";
        if (Price <= 0)
            result += "The price cannot be zero or negative;\n";
        if (result == "")
            result = "VALID";

        return result;
    }

    public override string ToString()
    {
        return $"{Name}  -  R$ {Price}";
    }
    public override bool Equals(object obj)
    {
        return obj is ServiceModel service &&
               Id == service.Id &&
               Name == service.Name &&
               Price == service.Price;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Price);
    }
}

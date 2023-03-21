namespace TCC_PUC_Tech_Barbershop.Domain.Shared;

public abstract class PersonModule : BaseEntity
{
    public string Name { get; set; }

    public string ValidatePerson()
    {
        string result = "";

        if (Name.Length == 0 || Name.Length > 50)
            result = $"The name length cannot be null or greater than 50\nCurrent length: {Name.Length}";
        if (result == "")
            result = "VALID";

        return result;
    }
}

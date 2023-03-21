namespace TCC_PUC_Tech_Barbershop.Domain.Shared;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public abstract string Validate();
}

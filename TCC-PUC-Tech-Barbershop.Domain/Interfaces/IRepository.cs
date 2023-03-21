using TCC_PUC_Tech_Barbershop.Domain.Shared;

namespace TCC_PUC_Tech_Barbershop.Domain.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    bool InsertNew(T registry);
    bool Edit(int id, T registry);
    bool Exist(int id);
    bool Delete(int id);
    List<T> SelectAll();
    T SelectById(int id);
}

using Data.Entities;

namespace Data.Interfaces;

public interface IStatusTypeRepository : IBaseRepository<StatusTypeEntity>
{
    new Task<IEnumerable<StatusTypeEntity>> GetAsync();
    //Task<IEnumerable<object>> GetAsync();
}

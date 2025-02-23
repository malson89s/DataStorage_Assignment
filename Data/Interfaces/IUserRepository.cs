using Data.Entities;

namespace Data.Interfaces;

public interface IUserRepository : IBaseRepository<UserEntity>
{
    Task AddAsync(object userEntity);
    Task UpdateAsync(UserEntity existingUser);
    Task DeleteAsync(UserEntity existingUser);
}



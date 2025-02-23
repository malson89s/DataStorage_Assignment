using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class UserRepository(DataContext context) : BaseRepository<UserEntity>(context), IUserRepository
{
    private readonly DataContext _context = context;

    public Task AddAsync(object userEntity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(UserEntity existingUser)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UserEntity existingUser)
    {
        throw new NotImplementedException();
    }
}



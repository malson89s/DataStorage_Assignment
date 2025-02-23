using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class UserFactory
{
    public static UserModel Create(UserEntity entity) 
    {
        return new UserModel 
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email
        };
    }

    internal static object Create(UserModel userModel)
    {
        throw new NotImplementedException();
    }
}

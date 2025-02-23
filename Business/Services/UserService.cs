using Business.Factories;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    // Hämta alla användare
    public async Task<IEnumerable<UserModel>> GetUsersAsync()
    {
        var userEntities = await _userRepository.GetAsync();
        return userEntities.Select(UserFactory.Create);
    }

    // Hämta användare via ID
    public async Task<UserModel?> GetUserByIdAsync(int id)
    {
        var userEntity = await _userRepository.GetAsync(u => u.Id == id);
        return userEntity == null ? null : UserFactory.Create(userEntity);
    }

    // Skapa en ny användare
    public async Task<bool> CreateUserAsync(UserModel userModel)
    {
        if (await _userRepository.AlreadyExistsAsync(u => u.Email == userModel.Email))
            return false; // Förhindra duplicerade e-postadresser

        var userEntity = UserFactory.Create(userModel);
        await _userRepository.AddAsync(userEntity);
        return true;
    }

    // Uppdatera användare
    public async Task<bool> UpdateUserAsync(UserModel userModel)
    {
        var existingUser = await _userRepository.GetAsync(u => u.Id == userModel.Id);
        if (existingUser == null)
            return false;

        existingUser.FirstName = userModel.FirstName;
        existingUser.LastName = userModel.LastName;
        existingUser.Email = userModel.Email;

        await _userRepository.UpdateAsync(existingUser);
        return true;
    }

    // Radera användare
    public async Task<bool> DeleteUserAsync(int id)
    {
        var existingUser = await _userRepository.GetAsync(u => u.Id == id);
        if (existingUser == null)
            return false;

        await _userRepository.DeleteAsync(existingUser);
        return true;
    }
}
//Hjälp av chatgpt

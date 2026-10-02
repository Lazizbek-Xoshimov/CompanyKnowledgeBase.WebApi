using CompanyKnowledgeBase.WebApi.Brokers;
using CompanyKnowledgeBase.WebApi.Models;
using CompanyKnowledgeBase.WebApi.Services.DTOs;
using System.ComponentModel.DataAnnotations;

namespace CompanyKnowledgeBase.WebApi.Services;

public class UserService : IUserService
{
    private readonly IStorageBroker _storageBroker;

    public UserService()
    {
        _storageBroker = new StorageBroker();
    }

    public async Task<bool> AddUserAsync(CreateUserDto user)
    {
        if (!Enum.IsDefined(user.UserRole))
            return false;

        var createdUser = new User();
        createdUser.FirstName = user.FirstName;
        createdUser.LastName = user.LastName;
        createdUser.Email = user.Email;
        createdUser.UserRole = user.UserRole;
        createdUser.Password = user.Password;

        createdUser.CreatedDate = DateTimeOffset.UtcNow;
        createdUser.UpdatedDate = createdUser.CreatedDate;

        return await _storageBroker.InsertUserAsync(createdUser);
    }

    public async Task<IEnumerable<User>> RetriveAllUserAsync()
    {
        return await _storageBroker.SelectAllUserAsync();
    }

    public async Task<User> RetriveUserByIdAsync(int userId)
    {
        var user = await _storageBroker.SelectUserById(userId);

        if (user is null)
            return null;

        return user;
    }

    public async Task<bool> UpdateUserAsync(int userId, UpdateUserDto user)
    {
        var oldUser = await RetriveUserByIdAsync(userId);

        if (oldUser is null)
            return false;

        var updatedUser = new User();

        updatedUser.FirstName = user.FirstName;
        updatedUser.LastName = user.LastName;
        updatedUser.Email = user.Email;
        updatedUser.UserRole = user.UserRole;
        updatedUser.Password = user.Password;
        updatedUser.CreatedDate = oldUser.CreatedDate;

        updatedUser.UpdatedDate = DateTime.Now;

        return await _storageBroker.UpdateUserAsync(userId, updatedUser);
    }

    public async Task<bool> DeleteUserAsync(int userId)
    {
        var users = await RetriveAllUserAsync();

        if (!users.Select(u => u.Id).Contains(userId))
            return false;

        return await _storageBroker.DeleteUserAsync(userId);
    }
}

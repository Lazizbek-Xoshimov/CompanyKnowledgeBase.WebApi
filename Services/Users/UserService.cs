using Brokers;
using Models.Users;
using Models.Exceptions;

namespace Services.Users;

public class UserService : IUserService
{
    public readonly IStorageBroker storageUser;

    public UserService()
    {
        storageUser = new StorageBroker();
    }

    public async Task<bool> AddUserAsync(User user)
    {
        var users = await RetriveAllUserAsync();

        if (users.Select(u => u.Id).Contains(user.Id))
            throw new ValidationException($"{user.Id} user is exsits.", "Use another user Id.");

        return await storageUser.InsertUserAsync(user);
    }

    public async Task<IEnumerable<User>> RetriveAllUserAsync()
    {
        return await storageUser.SelectAllUserAsync();
    }

    public async Task<User> RetriveUserById(int userId)
    {
        var user = await storageUser.SelectUserById(userId);

        if (user is null)
            throw new NotFoundException($"{userId} user was not found.", "Use a different Id");

        return user;
    }

    public async Task<bool> UpdateUserAsync(User user)
    {
        var users = await storageUser.SelectAllUserAsync();

        if (!users.Select(p => p.Id).Contains(user.Id))
            throw new NotFoundException($"{user.Id} user is not exsits.", "Use another user Id.");

        return await storageUser.UpdateUserAsync(user);
    }

    public async Task<bool> DeleteUserAsync(int userId)
    {
        var users = await storageUser.SelectAllUserAsync();

        if (!users.Select(u => u.Id).Contains(userId))
            throw new NotFoundException($"{userId} user is exsits.", "Use another user Id.");

        return await storageUser.DeleteUserAsync(userId);
    }
}
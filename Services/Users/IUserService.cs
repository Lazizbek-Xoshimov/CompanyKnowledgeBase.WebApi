using Models.Users;

namespace Services.Users;

public interface IUserService
{
    public Task<bool> AddUserAsync(User user);
    public Task<IEnumerable<User>> RetriveAllUserAsync();
    public Task<User> RetriveUserById(int userId);
    public Task<bool> UpdateUserAsync(User user);
    public Task<bool> DeleteUserAsync(int userId);
}
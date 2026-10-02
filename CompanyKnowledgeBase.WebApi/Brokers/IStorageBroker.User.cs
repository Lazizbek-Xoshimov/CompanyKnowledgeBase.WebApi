using CompanyKnowledgeBase.WebApi.Models;

namespace CompanyKnowledgeBase.WebApi.Brokers;

public partial interface IStorageBroker
{
    public Task<bool> InsertUserAsync(User user);
    public Task<IEnumerable<User>> SelectAllUserAsync();
    public Task<User> SelectUserById(int userId);
    public Task<bool> UpdateUserAsync(int userId, User user);
    public Task<bool> DeleteUserAsync(int userId);
}

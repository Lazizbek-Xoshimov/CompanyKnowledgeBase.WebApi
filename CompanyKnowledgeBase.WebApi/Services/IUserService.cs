using CompanyKnowledgeBase.WebApi.Models;
using CompanyKnowledgeBase.WebApi.Services.DTOs;

namespace CompanyKnowledgeBase.WebApi.Services;

public interface IUserService
{
    public Task<bool> AddUserAsync(CreateUserDto user);
    public Task<IEnumerable<User>> RetriveAllUserAsync();
    public Task<User> RetriveUserByIdAsync(int userId);
    public Task<bool> UpdateUserAsync(int userId, UpdateUserDto user);
    public Task<bool> DeleteUserAsync(int userId);
}

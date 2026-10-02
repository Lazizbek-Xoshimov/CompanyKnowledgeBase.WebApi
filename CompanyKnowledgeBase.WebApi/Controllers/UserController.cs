using CompanyKnowledgeBase.WebApi.Models;
using CompanyKnowledgeBase.WebApi.Services;
using CompanyKnowledgeBase.WebApi.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CompanyKnowledgeBase.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController()
    {
        _userService = new UserService();
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync([FromBody] CreateUserDto user)
    {
        var isAdded = await _userService.AddUserAsync(user);

        if (!isAdded)
            return BadRequest(new { message = "User was not created" });

        return Ok(new { message = "User created" });
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAsync()
    {
        var users = await _userService.RetriveAllUserAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetByIdAsync(int id)
    {
        var user = await _userService.RetriveUserByIdAsync(id);

        if (user is null)
            return NotFound(new { message = "User not found. Try a different ID" });

        return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAsync(int id, [FromBody] UpdateUserDto user)
    {
        var isUpdated = await _userService.UpdateUserAsync(id, user);

        if (!isUpdated)
            return NotFound(new { message = "User not found. Try a different ID" });

        return Ok(new { message = "User updated" });
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var isDeleted = await _userService.DeleteUserAsync(id);

        if (!isDeleted)
            return NotFound(new { message = "User not found. Try a different ID" });

        return Ok(new { message = "User deleted" });
    }
}

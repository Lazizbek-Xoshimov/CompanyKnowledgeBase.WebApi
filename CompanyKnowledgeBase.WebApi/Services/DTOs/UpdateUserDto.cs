using CompanyKnowledgeBase.WebApi.Models;
using System.Text.Json.Serialization;

namespace CompanyKnowledgeBase.WebApi.Services.DTOs;

public class UpdateUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public UserRole UserRole { get; set; }
    public string Password { get; set; }
}

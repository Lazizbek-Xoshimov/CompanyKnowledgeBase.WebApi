using CompanyKnowledgeBase.WebApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CompanyKnowledgeBase.WebApi.Services.DTOs;

public class CreateUserDto
{
    [StringLength(100)]
    public string FirstName { get; set; }

    [StringLength(100)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; }

    [Required]
    [EnumDataType(typeof(UserRole))]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public UserRole UserRole { get; set; }

    [StringLength(10)]
    public string Password { get; set; }
}

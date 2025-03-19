using System.ComponentModel.DataAnnotations;

namespace AccountManager.Application.DTOs.User;

public record class CreateUserDTO(
    [Required] string Name,
    [Required, EmailAddress] string Email,
    [Required] string Password
)
{

}

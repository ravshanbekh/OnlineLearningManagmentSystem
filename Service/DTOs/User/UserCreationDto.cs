using Domain.Enums;

namespace Service.DTOs.User;

public class UserCreationDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}

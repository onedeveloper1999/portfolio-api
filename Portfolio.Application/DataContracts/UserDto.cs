using Portfolio.Core.Enums;

namespace Portfolio.Application.DataContracts;
public record UserDto
{
    public string Username { get; init; } = string.Empty;
    public string PasswordHash { get; init; } = string.Empty;
    public Role Role { get; init; } = Role.Guest;
}

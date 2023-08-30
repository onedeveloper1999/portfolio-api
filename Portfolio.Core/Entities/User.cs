using Portfolio.Core.Enums;

namespace Portfolio.Core.Entities;
public class User : BaseEntity
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public Role Role { get; set; } = Role.Guest;
}

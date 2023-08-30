using Portfolio.Core.Entities;

namespace Portfolio.Core.Interfaces;
public interface IUserRepository
{
    Task<List<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(int userId);
    Task<User?> AddUserAsync(User user);
    Task<User?> UpdateUserAsync(int userId, User user);
    Task<bool> DeleteUserAsync(int userId);
}
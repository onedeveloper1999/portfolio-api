using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Entities;
using Portfolio.Core.Interfaces;
using Portfolio.Infrastructure.Persistence;

namespace Portfolio.Infrastructure.Repositories;
public class UserRepository(PortfolioContext portfolioContext) : IUserRepository
{
    public async Task<User?> AddUserAsync(User user)
    {
        portfolioContext.Users.Add(user);
        int rowsAdded = await portfolioContext.SaveChangesAsync();
        return rowsAdded == 0 ? null : user;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await portfolioContext.Users.ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(int userId)
    {
        return await portfolioContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
    }

    public async Task<User?> UpdateUserAsync(int userId, User user)
    {
        var rowsUpdated = await portfolioContext.Users.Where(x => x.Id == userId).ExecuteUpdateAsync(x => x.SetProperty(x => x, user));
        return rowsUpdated == 1 ? user : null;
    }

    public async Task<bool> DeleteUserAsync(int userId)
    {
        var rowsDeleted = await portfolioContext.Projects.Where(x => x.Id == userId).ExecuteDeleteAsync();
        return rowsDeleted == 1;
    }

}

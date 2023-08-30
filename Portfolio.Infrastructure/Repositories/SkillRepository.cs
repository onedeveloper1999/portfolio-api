using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Entities;
using Portfolio.Core.Interfaces;
using Portfolio.Infrastructure.Persistence;

namespace Portfolio.Infrastructure.Repositories;
public class SkillRepository(PortfolioContext portfolioContext) : ISkillRepository
{
    public async Task<List<Skill>> AddSkillAsync(List<Skill> skills)
    {
        await portfolioContext.Skills.AddRangeAsync(skills);
        int rowsAdded = await portfolioContext.SaveChangesAsync();
        return rowsAdded == 0 ? new List<Skill>() : skills;
    }

    public async Task<List<Skill>> GetAllSkillsAsync()
    {
        return await portfolioContext.Skills.ToListAsync();
    }

    public async Task<Skill?> GetSkillByIdAsync(int skillId)
    {
        return await portfolioContext.Skills.FirstOrDefaultAsync(x => x.Id == skillId);
    }

    public async Task<Skill?> UpdateSkillAsync(int skillId, Skill skill)
    {
        var rowsUpdated = await portfolioContext.Skills.Where(x => x.Id == skillId).ExecuteUpdateAsync(x => x.SetProperty(x => x, skill));
        return rowsUpdated == 1 ? skill : null;
    }

    public async Task<bool> DeleteSkillAsync(int skillId)
    {
        var rowsDeleted = await portfolioContext.Skills.Where(x => x.Id == skillId).ExecuteDeleteAsync();
        return rowsDeleted == 1;
    }

}

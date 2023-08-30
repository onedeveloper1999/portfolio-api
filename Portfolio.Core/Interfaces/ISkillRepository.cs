using Portfolio.Core.Entities;

namespace Portfolio.Core.Interfaces;
public interface ISkillRepository
{
    Task<List<Skill>> GetAllSkillsAsync();
    Task<Skill?> GetSkillByIdAsync(int skillId);
    Task<List<Skill>> AddSkillAsync(List<Skill> skills);
    Task<Skill?> UpdateSkillAsync(int skillId, Skill skill);
    Task<bool> DeleteSkillAsync(int skillId);
}
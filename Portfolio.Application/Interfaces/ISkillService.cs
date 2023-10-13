using Portfolio.Application.DataContracts;

namespace Portfolio.Application.Interfaces;
public interface ISkillService
{
    Task<ApiResponse> AddSkillAsync(List<SkillDto> SkillDtos);
    Task<ApiResponse> GetAllSkillsAsync();
    Task<ApiResponse> GetSkillByIdAsync(int SkillId);
    Task<ApiResponse> UpdateSkillAsync(int SkillId, SkillDto SkillDto);
    Task<ApiResponse> DeleteSkillAsync(int SkillId);
}

using Portfolio.Application.DataContracts;
using Portfolio.Application.Interfaces;
using Portfolio.Core.Constants;
using Portfolio.Core.Entities;
using Portfolio.Core.Interfaces;
using System.Net;

namespace Portfolio.Application.Services;
public class SkillService(ISkillRepository skillRepository) : ISkillService
{
    public async Task<ApiResponse> AddSkillAsync(List<SkillDto> SkillDtos)
    {
        var skills = new List<Skill>();
        SkillDtos.ForEach(x =>
        {
            var skill = new Skill { Name = x.Name, Description = x.Description, Category = x.Category };
            skills.Add(skill);
        });
        var result = await skillRepository.AddSkillAsync(skills);
        return new ApiResponse(ApiResponseMessage.Success, result, HttpStatusCode.OK);
    }

    public async Task<ApiResponse> DeleteSkillAsync(int SkillId)
    {
        var result = await skillRepository.DeleteSkillAsync(SkillId);
        return new ApiResponse(ApiResponseMessage.Success, result, HttpStatusCode.OK);
    }

    public async Task<ApiResponse> GetAllSkillsAsync()
    {
        var result = await skillRepository.GetAllSkillsAsync();
        return new ApiResponse(ApiResponseMessage.Success, result, HttpStatusCode.OK);
    }

    public async Task<ApiResponse> GetSkillByIdAsync(int SkillId)
    {
        var result = await skillRepository.GetSkillByIdAsync(SkillId);
        return new ApiResponse(ApiResponseMessage.Success, result, HttpStatusCode.OK);
    }

    public async Task<ApiResponse> UpdateSkillAsync(int SkillId, SkillDto SkillDto)
    {
        var skill = new Skill { Name = SkillDto.Name, Description = SkillDto.Description, Category = SkillDto.Category };
        var result = await skillRepository.UpdateSkillAsync(SkillId, skill);
        return new ApiResponse(ApiResponseMessage.Success, result, HttpStatusCode.OK);
    }
}

using Portfolio.Application.DataContracts;
using Portfolio.Application.Interfaces;
using Portfolio.Core.Constants;
using Portfolio.Core.Entities;
using Portfolio.Core.Interfaces;
using System.Net;

namespace Portfolio.Application.Services;
public class ProjectService (IProjectRepository projectRepository) : IProjectService
{
    public async Task<ApiResponse> AddProjectAsync(ProjectDto ProjectDto)
    {
        var project = new Project
        {
            Title = ProjectDto.Title,
            Description = ProjectDto.Description,
            TechnologiesUsed = ProjectDto.TechnologiesUsed,
            ImageUrl = ProjectDto.ImageUrl,
            GitHubLink = ProjectDto.GitHubLink,
            WebsiteLink = ProjectDto.WebsiteLink
        };
        var result = await projectRepository.AddProjectAsync(project);
        return new ApiResponse(ApiResponseMessage.Success, result, HttpStatusCode.OK);
    }

    public async Task<ApiResponse> DeleteProjectAsync(int ProjectId)
    {
        var result = await projectRepository.DeleteProjectAsync(ProjectId);
        return new ApiResponse(ApiResponseMessage.Success, result, HttpStatusCode.OK);
    }

    public async Task<ApiResponse> GetAllProjectsAsync()
    {
        var result = await projectRepository.GetAllProjectsAsync();
        return new ApiResponse(ApiResponseMessage.Success, result, HttpStatusCode.OK);
    }

    public async Task<ApiResponse> GetProjectByIdAsync(int ProjectId)
    {
        var result = await projectRepository.GetProjectByIdAsync(ProjectId);
        return new ApiResponse(ApiResponseMessage.Success, result, HttpStatusCode.OK);
    }

    public async Task<ApiResponse> UpdateProjectAsync(int ProjectId, ProjectDto ProjectDto)
    {
        var project = new Project
        {
            Title = ProjectDto.Title,
            Description = ProjectDto.Description,
            TechnologiesUsed = ProjectDto.TechnologiesUsed,
            ImageUrl = ProjectDto.ImageUrl,
            GitHubLink = ProjectDto.GitHubLink,
            WebsiteLink = ProjectDto.WebsiteLink
        };
        var result = await projectRepository.UpdateProjectAsync(ProjectId,project);
        return new ApiResponse(ApiResponseMessage.Success, result, HttpStatusCode.OK);
    }
}

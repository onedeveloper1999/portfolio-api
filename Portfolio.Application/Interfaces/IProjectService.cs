using AutoWrapper.Wrappers;
using Portfolio.Application.DataContracts;

namespace Portfolio.Application.Interfaces;
public interface IProjectService
{
    Task<ApiResponse> AddProjectAsync(ProjectDto ProjectDto);
    Task<ApiResponse> GetAllProjectsAsync();
    Task<ApiResponse> GetProjectByIdAsync(int ProjectId);
    Task<ApiResponse> UpdateProjectAsync(int ProjectId, ProjectDto ProjectDto);
    Task<ApiResponse> DeleteProjectAsync(int ProjectId);
}

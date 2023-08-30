using Portfolio.Core.Entities;

namespace Portfolio.Core.Interfaces;
public interface IProjectRepository
{
    Task<List<Project>> GetAllProjectsAsync();
    Task<Project?> GetProjectByIdAsync(int projectId);
    Task<Project?> AddProjectAsync(Project project);
    Task<Project?> UpdateProjectAsync(int projectId, Project project);
    Task<bool> DeleteProjectAsync(int projectId);
}
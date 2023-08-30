using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Entities;
using Portfolio.Core.Interfaces;
using Portfolio.Infrastructure.Persistence;

namespace Portfolio.Infrastructure.Repositories;
public class ProjectRepository(PortfolioContext portfolioContext) : IProjectRepository
{
    public async Task<Project?> AddProjectAsync(Project project)
    {
        portfolioContext.Projects.Add(project);
        int rowsAdded = await portfolioContext.SaveChangesAsync();
        return rowsAdded == 0 ? null : project;
    }

    public async Task<List<Project>> GetAllProjectsAsync()
    {
        return await portfolioContext.Projects.ToListAsync();
    }

    public async Task<Project?> GetProjectByIdAsync(int projectId)
    {
        return await portfolioContext.Projects.FirstOrDefaultAsync(x=>x.Id == projectId);
    }

    public async Task<Project?> UpdateProjectAsync(int projectId, Project project)
    {
        int rowsUpdated = await portfolioContext.Projects.Where(x => x.Id == projectId).ExecuteUpdateAsync(x => x.SetProperty(x => x, project));
        return rowsUpdated == 1 ? project : null;
    }

    public async Task<bool> DeleteProjectAsync(int projectId)
    {
        var rowsDeleted = await portfolioContext.Projects.Where(x => x.Id == projectId).ExecuteDeleteAsync();
        return rowsDeleted == 1;
    }
}
 
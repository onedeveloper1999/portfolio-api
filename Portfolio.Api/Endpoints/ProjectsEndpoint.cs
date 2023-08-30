using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.Endpoints.Filters;
using Portfolio.Api.Endpoints.Helpers;
using Portfolio.Application.DataContracts;
using Portfolio.Application.Interfaces;

namespace Portfolio.Api.Endpoints;

public class ProjectsEndpoint : IEndpoint
{
    private const string projectEndpointTag = "Project";
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder routeBuilder)
    {
        var projectGroup = routeBuilder.MapGroup(projectEndpointTag.ToLower()).WithTags(projectEndpointTag);

        projectGroup.MapGet(string.Empty, async ([FromServices] IProjectService projectService, HttpContext context) =>
        {
            return await projectService.GetAllProjectsAsync();
        });

        projectGroup.MapGet("/{projectId:int}", async (int projectId, [FromServices] IProjectService projectService) => await projectService.GetProjectByIdAsync(projectId));

        projectGroup.MapPost(string.Empty, async ([FromBody] ProjectDto projectDto, [FromServices] IProjectService projectService) =>
        {
            return await projectService.AddProjectAsync(projectDto);
        }).AddEndpointFilter<ValidationFilter<ProjectDto>>();

        projectGroup.MapDelete("/{projectId:int}", async (int projectId, [FromServices] IProjectService projectService) => await projectService.DeleteProjectAsync(projectId));

        projectGroup.MapPut("/{projectId:int}", async (int projectId, ProjectDto projectDto, [FromServices] IProjectService projectService) => await projectService.UpdateProjectAsync(projectId, projectDto));

        return routeBuilder;
    }
}

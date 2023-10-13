using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.Endpoints.Filters;
using Portfolio.Api.Endpoints.Helpers;
using Portfolio.Application.DataContracts;
using Portfolio.Application.Interfaces;

namespace Portfolio.Api.Endpoints;

public class SkillsEndpoint : IEndpoint
{
    private const string skillEndpointTag = "Skill";
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder routeBuilder)
    {
        var skillGroup = routeBuilder.MapGroup(skillEndpointTag.ToLower()).WithTags(skillEndpointTag);

        skillGroup.MapGet(string.Empty, async ([FromServices] ISkillService skillService) => await skillService.GetAllSkillsAsync());

        skillGroup.MapGet("/{skillId:int}", async (int skillId, [FromServices] ISkillService skillService) => await skillService.GetSkillByIdAsync(skillId));

        skillGroup.MapPost(string.Empty, async ([FromBody] List<SkillDto> skillDtos, [FromServices] ISkillService skillService)
                                                                                                    => await skillService.AddSkillAsync(skillDtos))
                                                                                                                        .AddEndpointFilter<ValidationFilter<SkillDto>>();

        skillGroup.MapDelete("/{skillId:int}", async (int skillId, [FromServices] ISkillService skillService) => await skillService.DeleteSkillAsync(skillId));

        skillGroup.MapPut("/{skillId:int}", async (int skillId, SkillDto skillDto, [FromServices] ISkillService skillService) => await skillService.UpdateSkillAsync(skillId, skillDto));

        return routeBuilder;
    }
}

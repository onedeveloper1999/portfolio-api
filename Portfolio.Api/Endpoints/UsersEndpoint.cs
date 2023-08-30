using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.Endpoints.Filters;
using Portfolio.Api.Endpoints.Helpers;
using Portfolio.Application.DataContracts;
using Portfolio.Application.Interfaces;

namespace Portfolio.Api.Endpoints;

public class UsersEndpoint : IEndpoint
{
    private const string userEndpointTag = "User";
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder routeBuilder)
    {
        var userGroup = routeBuilder.MapGroup(userEndpointTag.ToLower()).WithTags(userEndpointTag);

        userGroup.MapGet(string.Empty, async ([FromServices] IUserService userService, HttpContext context) =>
        {
            return await userService.GetAllUsersAsync();
        });

        userGroup.MapGet("/{userId:int}", async (int userId, [FromServices] IUserService userService) => await userService.GetUserByIdAsync(userId));

        userGroup.MapPost(string.Empty, async ([FromBody] UserDto userDto, [FromServices] IUserService userService) =>
        {
            return await userService.AddUserAsync(userDto);
        }).AddEndpointFilter<ValidationFilter<UserDto>>();

        userGroup.MapDelete("/{userId:int}", async (int userId, [FromServices] IUserService userService) => await userService.DeleteUserAsync(userId));

        userGroup.MapPut("/{userId:int}", async (int userId, UserDto userDto, [FromServices] IUserService userService) => await userService.UpdateUserAsync(userId, userDto));

        return routeBuilder;
    }
}

using Microsoft.AspNetCore.Diagnostics;
using Portfolio.Application.DataContracts;
using System.Net;

namespace Portfolio.Api.Endpoints.Helpers;

public class ErrorsEndpoint : IEndpoint
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.Map("/error", async (HttpContext context, ILogger<ErrorsEndpoint> logger) =>
        {
            Exception? exception = null;
            var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
            if (exceptionFeature is not null)
            {
                exception = exceptionFeature.Error;
                if (exception is not null)
                {
                    var stackStrace = exception.StackTrace;
                    var errorMessage = exception.Message;
                    logger.LogInformation(stackStrace);
                    logger.LogError(errorMessage);
                }
            }
            await context.Response.WriteAsJsonAsync<ApiResponse>(new ApiResponse(message: exception is null ? "Error" : exception.Message, result: null, statusCode: HttpStatusCode.InternalServerError));
        });
        return routeBuilder;
    }
}

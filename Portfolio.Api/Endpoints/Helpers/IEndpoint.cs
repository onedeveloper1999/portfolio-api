namespace Portfolio.Api.Endpoints.Helpers;

public interface IEndpoint
{
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder routeBuilder);
}

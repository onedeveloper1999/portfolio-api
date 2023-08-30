namespace Portfolio.Api.Endpoints.Helpers;

public static class EndpointExtension
{
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        var registeredEnpoints = DiscoverEndPoints();
        registeredEnpoints.ToList().ForEach(x => x.MapEndpoints(app));

        return app;
    }
    private static IEnumerable<IEndpoint> DiscoverEndPoints()
    {
        return typeof(IEndpoint).Assembly
            .GetTypes()
            .Where(p => p.IsClass && p.IsAssignableTo(typeof(IEndpoint)))
            .Select(Activator.CreateInstance)
            .Cast<IEndpoint>();
    }
}

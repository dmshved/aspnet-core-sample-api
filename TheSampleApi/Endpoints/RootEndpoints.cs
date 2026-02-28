namespace TheSampleApi.Endpoints;
public static class RootEndpoints
{
    // Just a dummy endpoint
    public static void AddRootEndpoints(this WebApplication app)
    {
        app.MapGet("/", () => "hi there");
    }
}

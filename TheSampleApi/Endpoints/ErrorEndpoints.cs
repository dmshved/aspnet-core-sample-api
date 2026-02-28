namespace TheSampleApi.Endpoints;
public static class ErrorEndpoints
{
    // WARNING: This route is for educational purposes only!
    public static void AddErrorEndpoints(this WebApplication app)
    {
        app.MapGet("/error/{code}", (int code) =>
        {
            return code switch
            {
                400 => Results.BadRequest(),
                401 => Results.Unauthorized(),
                403 => Results.Forbid(),
                404 => Results.NotFound(),
                _ => Results.StatusCode(code)
            };
        });
    }
}

using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TheSampleApi.HealthChecks;

public class RandomHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        int randomResult = Random.Shared.Next(1, 4); // healthy, degraded, unhealthy

        return randomResult switch
        {
            1 => Task.FromResult(HealthCheckResult.Healthy("Random HealthChecker: Healthy :D")),
            2 => Task.FromResult(HealthCheckResult.Degraded("Random HealthChecker: Degraded :|")),
            3 => Task.FromResult(HealthCheckResult.Unhealthy("Random HealthChecker: Unhealthy X(")),
            _ => Task.FromResult(HealthCheckResult.Unhealthy("wtf is going on here :/")),
        };
    }
}

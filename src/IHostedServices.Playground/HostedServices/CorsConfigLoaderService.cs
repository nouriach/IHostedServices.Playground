namespace IHostedServices.Playground.HostedServices;

public class CorsConfigLoaderService : IHostedService
{
    private readonly ILogger<CorsConfigLoaderService> _logger;

    public CorsConfigLoaderService(ILogger<CorsConfigLoaderService> logger)
    {
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("StartAsync");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("StopAsync");
        return Task.CompletedTask;
    }
}
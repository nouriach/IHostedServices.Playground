using IHostedServices.Playground.Clients;

namespace IHostedServices.Playground.HostedServices;

public class CorsConfigLoaderService : IHostedService
{
    private readonly ILogger<CorsConfigLoaderService> _logger;
    private readonly IBreweryApiClient _breweryApiClient;
    public CorsConfigLoaderService(ILogger<CorsConfigLoaderService> logger, IBreweryApiClient breweryApiClient)
    {
        _logger = logger;
        _breweryApiClient = breweryApiClient;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("---> StartAsync: retrieving domains.");
        
        var allowedOrigins = await _breweryApiClient.GetAllowedOrigins(cancellationToken);
        if (allowedOrigins is not null && allowedOrigins.Length > 0)
        {
            for (var i = 0; i < allowedOrigins.Length; i++)
            {
                _logger.LogInformation($"---> Adding domain as Environment Variable: {allowedOrigins[i]}");
                Environment.SetEnvironmentVariable($"AllowedOrigins__{i}", allowedOrigins[i]);
            }
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("---> StopAsync");
        return Task.CompletedTask;
    }
}
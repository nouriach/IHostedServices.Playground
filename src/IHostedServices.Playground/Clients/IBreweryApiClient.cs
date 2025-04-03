namespace IHostedServices.Playground.Clients;

public interface IBreweryApiClient
{
    Task<string[]?> GetAllowedOrigins(CancellationToken cancellationToken);
}
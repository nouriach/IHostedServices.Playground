using System.Text.Json;
using IHostedServices.Playground.Configuration;
using IHostedServices.Playground.DTOs;
using Microsoft.Extensions.Options;

namespace IHostedServices.Playground.Clients;

public class BreweryApiClient : IBreweryApiClient
{
    private readonly HttpClient _client;
    private readonly ILogger<BreweryApiClient> _logger;
    private readonly IOptions<BreweryApiConfiguration> _options;

    public BreweryApiClient(HttpClient client, ILogger<BreweryApiClient> logger, IOptions<BreweryApiConfiguration> options)
    {
        _client = client;
        _logger = logger;
        _options = options;
    }

    public async Task<string[]?> GetAllowedOrigins(CancellationToken cancellationToken)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{_options.Value.Uri}?per_page=5");

        _logger.LogInformation($"---> About to send HttpRequest: {httpRequest}");
        var response = await _client.SendAsync(httpRequest, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogInformation("---> Request was unsuccessful");
            return Array.Empty<string>();
        }

        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        var breweries = JsonSerializer.Deserialize<List<BreweryDto>>(responseContent, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        });

        return breweries?.Select(b => b.WebsiteUrl).ToArray();
    }
}
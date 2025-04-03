using System.Text.Json.Serialization;

namespace IHostedServices.Playground.DTOs;

public class BreweryDto
{
    [JsonPropertyName("website_url")]
    public string WebsiteUrl { get; set; } = null!;
}
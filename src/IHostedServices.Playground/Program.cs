﻿using IHostedServices.Playground.Clients;
using IHostedServices.Playground.Configuration;
using IHostedServices.Playground.HostedServices;

var builder = WebApplication.CreateBuilder();

// configure your app
builder.Services.AddHostedService<CorsConfigLoaderService>();

builder.Services.Configure<BreweryApiConfiguration>(
    builder.Configuration.GetSection(BreweryApiConfiguration.SectionName)
);

builder.Services.AddHttpClient<IBreweryApiClient, BreweryApiClient>();

builder.Services.AddCors(options =>
{
    var domains = new List<string>();
    var index = 0;
    
    while (true)
    {
        var key = $"AllowedOrigins__{index}";
        var value = Environment.GetEnvironmentVariable(key);
        if (value is null) break;
        
        domains.Add(value);
        index++;
    }

    options.AddPolicy("AllowedClientDomains", policy =>
    {
        policy.WithOrigins(domains.ToArray())
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// build your app

app.UseCors("AllowedClientDomains");

app.MapGet("/allowedOrigins", () =>
{
    var response = new
    {
        ConfigResultOne = Environment.GetEnvironmentVariable("AllowedOrigins__0"),
        ConfigResultTwo = Environment.GetEnvironmentVariable("AllowedOrigins__1"),
        ConfigResultThree = Environment.GetEnvironmentVariable("AllowedOrigins__2"),
        ConfigResultFour = Environment.GetEnvironmentVariable("AllowedOrigins__3")
    };

    return Results.Ok(response);
});

app.Run();
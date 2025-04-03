using IHostedServices.Playground.Configuration;
using IHostedServices.Playground.HostedServices;

var builder = WebApplication.CreateBuilder();

// configure your app
builder.Services.AddHostedService<CorsConfigLoaderService>();

builder.Services.Configure<BreweryApiConfiguration>(
    builder.Configuration.GetSection(BreweryApiConfiguration.SectionName)
);

var app = builder.Build();

// build your app

app.Run();
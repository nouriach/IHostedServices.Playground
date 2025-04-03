using IHostedServices.Playground.HostedServices;

var builder = WebApplication.CreateBuilder();

// configure your app
builder.Services.AddHostedService<CorsConfigLoaderService>();

var app = builder.Build();

// build your app

app.Run();
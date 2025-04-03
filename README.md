# Dynamic CORS Configuration in .NET Using IHostedService 🔒
## Retrieve and update allowed client domains dynamically from an external API.

When building APIs, managing Cross-Origin Resource Sharing (CORS) is crucial, especially
when the list of allowed clients changes dynamically. In this repo, I use an `IHostedService`
to dynamically retrieve and update allowed client domains from an external API.

## Read the article 📰

> [Dynamic CORS Configuration in .NET Using IHostedService]()

## User Instructions 🔖

To interact with this repo you will need to have .NET installed on your machine. You can download the latest .NET version [here]("https://dotnet.microsoft.com/en-us/download").
This app is using .NET 8.

To monitor the code flow, run the app in debug mode and set breakpoints at key points of interest. The console logs will offer additional context.

## Considerations 🤔

`IHostedService` starts running during application startup but before the app is fully ready to handle requests. 
It initializes in the `StartAsync` method and stops gracefully via `StopAsync` when the app shuts down.

Using an IHostedService for complex, long-running tasks is not recommended. This approach may not be ideal for dynamically
setting allowed domains in a CORS policy, as it tightly couples the app to an external API. If the API request fails, the
app may never start. Proper error handling for HTTP failures is crucial.

## Resources 📚

- [How to Store and Retrieve Environment Variable in C#](https://mahmudx.com/how-to-store-and-retrieve-environment-variable-in-csharp)
- [Setting Environment Variables in C# for Better Application Configuration](https://www.webdevtutor.net/blog/c-sharp-set-environment-variable)
- [Configuration in ASP.NET Core](https://learn.microsoft.com/en-gb/aspnet/core/fundamentals/configuration/?view=aspnetcore-9.0#appsettingsjson)
- [How to override ASP.NET Core configuration array settings using environment variables](https://stackoverflow.com/questions/37657320/how-to-override-asp-net-core-configuration-array-settings-using-environment-vari)
- [Background tasks with hosted services in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-9.0&tabs=visual-studio)
- [Running async tasks on app startup in ASP.NET Core 3.0](https://andrewlock.net/running-async-tasks-on-app-startup-in-asp-net-core-3/)
- [Enable Cross-Origin Requests (CORS) in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-9.0)
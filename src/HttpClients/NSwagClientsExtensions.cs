using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcesoAutonomo.ServiceA.HttpClients.NSwagClients;

namespace ProcesoAutonomo.ServiceA.HttpClients;
public static class NSwagServiceAClientsExtensions
{
    public static IServiceCollection AddApiServiceAHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        var apiSettings = configuration.GetSection(nameof(NSwagServiceAClientsSettings)).Get<NSwagServiceAClientsSettings>();

        services.AddSingleton(new ClientCredentialsTokenRequest
        {
            Address = "https://localhost:5301/connect/token",
            ClientId = "RapidBlazorServer",
            ClientSecret = "RapidBlazorServerSecret",
            Scope = "ServiceA_scope"
        });

        services.AddHttpClient<IIdentityServerClient, IdentityServerClient>(client =>
        {
            client.BaseAddress = new Uri("https://localhost:5301");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        });

        services.AddTransient<ProtectedServiceABearerTokenHandler>();

        services.AddHttpClient<IWeatherForecastClient, WeatherForecastClient>(client => client.BaseAddress = new Uri("https://localhost:5001"))
            .AddHttpMessageHandler<ProtectedServiceABearerTokenHandler>();

        services.AddHttpClient<ITodoListsClient, TodoListsClient>(client => client.BaseAddress = new Uri("https://localhost:5001"))
            .AddHttpMessageHandler<ProtectedServiceABearerTokenHandler>();

        services.AddHttpClient<ITodoItemsClient, TodoItemsClient>(client => client.BaseAddress = new Uri("https://localhost:5001"))
            .AddHttpMessageHandler<ProtectedServiceABearerTokenHandler>();

        return services;
    }
}

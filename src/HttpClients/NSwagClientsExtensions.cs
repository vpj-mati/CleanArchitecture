using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcesoAutonomo.ServiceA.HttpClients.NSwagClients;

namespace ProcesoAutonomo.ServiceA.HttpClients;
public static class NSwagServiceAClientsExtensions
{
    public static IServiceCollection AddApiServiceAHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        var apiSettings = configuration.GetSection(nameof(NSwagServiceAClientsSettings)).Get<NSwagServiceAClientsSettings>();

        services.AddTransient<ProtectedServiceABearerTokenHandler>();

        services.AddHttpClient<IWeatherForecastClient, WeatherForecastClient>(client => client.BaseAddress = new Uri(apiSettings?.UriString ?? "" ))
            .AddHttpMessageHandler<ProtectedServiceABearerTokenHandler>();

        services.AddHttpClient<ITodoListsClient, TodoListsClient>(client => client.BaseAddress = new Uri(apiSettings?.UriString ?? ""))
            .AddHttpMessageHandler<ProtectedServiceABearerTokenHandler>();

        services.AddHttpClient<ITodoItemsClient, TodoItemsClient>(client => client.BaseAddress = new Uri(apiSettings?.UriString ?? ""))
            .AddHttpMessageHandler<ProtectedServiceABearerTokenHandler>();

        return services;
    }
}

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

        services.AddHttpClient<IWeatherForecastServiceAClient, WeatherForecastServiceAClient>(client => client.BaseAddress = new Uri(apiSettings?.UriString ?? "" ))
            .AddHttpMessageHandler<ProtectedServiceABearerTokenHandler>();

        services.AddHttpClient<ITodoListsServiceAClient, TodoListsServiceAClient>(client => client.BaseAddress = new Uri(apiSettings?.UriString ?? ""))
            .AddHttpMessageHandler<ProtectedServiceABearerTokenHandler>();

        services.AddHttpClient<ITodoItemsServiceAClient, TodoItemsServiceAClient>(client => client.BaseAddress = new Uri(apiSettings?.UriString ?? ""))
            .AddHttpMessageHandler<ProtectedServiceABearerTokenHandler>();

        return services;
    }
}

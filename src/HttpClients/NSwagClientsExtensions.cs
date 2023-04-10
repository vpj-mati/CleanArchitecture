using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcesoAutonomo.ServiceA.HttpClients.NSwagClients;

namespace ProcesoAutonomo.ServiceA.HttpClients;
public static class NSwagServiceAClientsExtensions
{
    public static IServiceCollection AddApiServiceAHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<NSwagServiceAClientsSettings>(options => configuration.GetSection(nameof(NSwagServiceAClientsSettings)).Bind(options));

        NSwagServiceAClientsSettings apiSettings = new();
        configuration.GetSection(nameof(NSwagServiceAClientsSettings)).Bind(apiSettings);

        var httpClient = new HttpClient() { BaseAddress = new Uri(apiSettings.UriString) };
        services.AddScoped<IWeatherForecastClient>(wc => new WeatherForecastClient(httpClient));
        services.AddScoped<ITodoListsClient>(tl => new TodoListsClient(httpClient));
        services.AddScoped<ITodoItemsClient>(ti => new TodoItemsClient(httpClient));

        return services;
    }
}

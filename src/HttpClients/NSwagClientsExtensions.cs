using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcesoAutonomo.ServiceA.HttpClients.NSwagClients;

namespace ProcesoAutonomo.ServiceA.HttpClients;
public static class NSwagClientsExtensions
{
    public static IServiceCollection AddApiServiceAHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<NSwagClientsSettings>(options => configuration.GetSection(nameof(NSwagClientsSettings)).Bind(options));

        NSwagClientsSettings apiSettings = new();
        configuration.GetSection(nameof(NSwagClientsSettings)).Bind(apiSettings);

        var httpClient = new HttpClient() { BaseAddress = new Uri(apiSettings.UriString) };
        services.AddScoped<IWeatherForecastClient>(wc => new WeatherForecastClient(httpClient));
        services.AddScoped<ITodoListsClient>(tl => new TodoListsClient(httpClient));
        //services.AddScoped<ITodoItemsClient>(ti => new TodoItemsClient(httpClient));

        return services;
    }
}

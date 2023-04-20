using MediatR;
using ProcesoAutonomo.ServiceA.Application.Objects.WeatherForecasts.Queries.GetWeatherForecasts;

namespace ProcesoAutonomo.ServiceA.Application.WeatherForecasts.Queries.GetWeatherForecasts;

public record GetWeatherForecastsQuery : IRequest<IEnumerable<WeatherForecast>>;

public class GetWeatherForecastsQueryHandler : IRequestHandler<GetWeatherForecastsQuery, IEnumerable<WeatherForecast>>
{
    private static readonly string[] Summaries = new[]
    {
        "Service A Freezing", "Service A Bracing", "Service A Chilly", "Service A Cool", "Service A Mild", "Service A Warm", "Service A Balmy", "Service A Hot", "Service A Sweltering", "Service A Scorching"
    };

    public async Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecastsQuery request, CancellationToken cancellationToken)
    {
        var rng = new Random();

        return await Task.FromResult(Enumerable.Range(1, 50).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = rng.Next(-20, 55),
            Summary = Summaries[rng.Next(Summaries.Length)]
        }));
    }
}

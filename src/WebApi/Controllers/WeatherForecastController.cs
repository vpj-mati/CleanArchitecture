using ProcesoAutonomo.ServiceA.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using Microsoft.AspNetCore.Mvc;
using ProcesoAutonomo.ServiceA.Application.Objects.WeatherForecasts.Queries.GetWeatherForecasts;

namespace ProcesoAutonomo.ServiceA.WebApi.Controllers;

public class WeatherForecastController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await Mediator.Send(new GetWeatherForecastsQuery());
    }
}

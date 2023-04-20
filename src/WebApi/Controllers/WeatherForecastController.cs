using ProcesoAutonomo.ServiceA.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using Microsoft.AspNetCore.Mvc;
using ProcesoAutonomo.ServiceA.Application.Objects.WeatherForecasts.Queries.GetWeatherForecasts;
using Microsoft.AspNetCore.Authorization;

namespace ProcesoAutonomo.ServiceA.WebApi.Controllers;

[Authorize]
public class WeatherForecastServiceAController : ApiControllerBase
{

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await Mediator.Send(new GetWeatherForecastsQuery());
    }
}

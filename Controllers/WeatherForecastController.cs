using System.Net.Mime;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Mvc;
using basic_api.Resources;
using basic_api.Core.Services;
using basic_api.Services;

namespace basic_api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{    
    private readonly ILogger<WeatherForecastController> _logger;

    private readonly IWeatherService _weatherService;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger,
        IWeatherService weatherService)
    {
        _logger = logger;
        _weatherService = weatherService;
    }

    // /weatherforecast/{city}
    // e.g. /weatherforecast/berlin
    [HttpGet()]
    public async Task<ActionResult<WeatherForecastResource>> GetAsync([FromQuery] string city)
    {
        if (string.IsNullOrWhiteSpace(city))
        {
            return BadRequest("City is required");
        }
        
        var weather = await _weatherService.GetWeatherForecastByCity(city);

        var weatherForecastResource = new WeatherForecastResource
        {
            Date = weather.Date,
            TemperatureC = weather.TemperatureC,
            Condition = weather.Condition
        };

        return weatherForecastResource;
    }
}

public class WeatherRequest
{
    public int Temperature { get; set; }
}


public class Error
{
    public string Text { get; set; }
}

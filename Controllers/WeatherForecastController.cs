using System.Net.Mime;
using System.Collections.ObjectModel;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace basic_api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static readonly ICollection<WeatherForecast> _forecasts = new Collection<WeatherForecast>();

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return _forecasts;
    }

    [HttpPost(Name = "CreateWeatherForecast")]
    public IActionResult Post([FromBody] WeatherRequest temperature)
    {
        var forecast = new WeatherForecast
        {
            Id = Guid.NewGuid(),
            Date = DateTime.Now,
            TemperatureC = temperature.Temperature,
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };

        _forecasts.Add(forecast);

        return Created("", forecast);
    }

    // localhost:5050/weatherforecast/1232-1312-1321-123213
    [HttpGet("{id}")]
    public ActionResult<WeatherForecast> GetById(Guid id)
    {
        var result = _forecasts.SingleOrDefault(f => f.Id == id);

        if (result is null)
        {
            return NotFound("ID not found");
        }

        return Ok(result);
    }

    // localhost:5050/weatherforecast/temperatures?temperature=...
    [HttpGet("temperatures")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(WeatherForecast[]), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
    public IActionResult GetByTemperature([FromQuery] int temperature)
    {
        // var result = new Collection<WeatherForecast>();
        // foreach(var forecast in _forecasts)
        // {
        //     if (forecast.TemperatureC == temperature)
        //     {
        //         result.Add(forecast);
        //     }
        // }

        var result = _forecasts.Where(forecast => forecast.TemperatureC == temperature);

        return Ok(result);
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

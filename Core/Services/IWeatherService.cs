using basic_api.Core.Models;

namespace basic_api.Core.Services;

public interface IWeatherService
{
    Task<WeatherForecast> GetWeatherForecastByCity(string city);
}

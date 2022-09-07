using basic_api.Clients;
using basic_api.Core.Clients;
using basic_api.Core.Models;
using basic_api.Core.Services;

namespace basic_api.Services;

public class WeatherService : IWeatherService
{
    private readonly IWeatherClient _weatherClient;
    
    public WeatherService(IWeatherClient weatherClient)
    {
        _weatherClient = weatherClient;
    }

    public async Task<WeatherForecast> GetWeatherForecastByCity(string city)
    {

        var weather = await _weatherClient.GetWeatherByCity(city);

        var weatherForecast = new WeatherForecast
        {
            Condition = weather.MyCurrentWeather.Condition.Text,
            Date = DateTime.Parse(weather.MyCurrentWeather.LastUpdate),
            TemperatureC = (int)weather.MyCurrentWeather.TemperatureC
        };

        return weatherForecast;
    }
}

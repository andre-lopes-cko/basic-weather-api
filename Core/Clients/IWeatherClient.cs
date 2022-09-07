using basic_api.Core.Clients.Models;

namespace basic_api.Core.Clients;

public interface IWeatherClient
{
    Task<Weather> GetWeatherByCity(string city);
}

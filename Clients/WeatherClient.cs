using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basic_api.Core.Clients;
using basic_api.Core.Clients.Models;

namespace basic_api.Clients;

public class WeatherClient : IWeatherClient
{
    private readonly HttpClient _httpClient;

    public WeatherClient(HttpClient client)
    {
        _httpClient = client;
    }

    public async Task<Weather> GetWeatherByCity(string city)
    {
        var uri = $"current.json?key=1345b47d25ca454d88885703220709&q={city}&aqi=no";

        var response = await _httpClient.GetFromJsonAsync<Weather>(uri);

        return response;
    }
}

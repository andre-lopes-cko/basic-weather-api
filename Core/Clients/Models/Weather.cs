using System.Text.Json.Serialization;

namespace basic_api.Core.Clients.Models;

public class Weather
{
    [JsonPropertyName("current")]
    public Current MyCurrentWeather { get; set; }
}

public class Current
{
    [JsonPropertyName("temp_c")]
    public double TemperatureC { get; set; }
    
    public Condition Condition { get; set; }

    [JsonPropertyName("last_updated")]
    public string LastUpdate { get; set; }
}

public class Condition
{
    [JsonPropertyName("text")]
    public string Text { get; set; }
}
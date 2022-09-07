namespace basic_api.Resources;

public class WeatherForecastResource
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Condition { get; set; }
}

namespace WFWT_Frontend.Data;

public class WeatherForecastService
{
    private readonly HttpClient _httpClient;
    public WeatherForecastService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async Task<WeatherForecast[]> GetForecastAsync(DateOnly startDate)
    {
        /*
        return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray());
        */
        var response = await _httpClient.GetFromJsonAsync<WeatherForecast[]>("weatherforecast");
        return response ?? Array.Empty<WeatherForecast>();
    }
}

using System.Net.Http.Json;
using WeatherUI.Shared;

namespace WeatherUI.Client.ApiClients;

public class WeatherForecastsHttpClientService
{
    private readonly string _apiResx = "/api/weatherforecasts";

    private readonly HttpClient _client;


    public WeatherForecastsHttpClientService(HttpClient httpClient) => _client = httpClient;


    public async Task<IEnumerable<WeatherForecast>> GetForecastAsync()
    {
        // As exception handling is not implemented, then let then be thrown up.
        return await _client.GetFromJsonAsync<WeatherForecast[]>(_apiResx)
            ?? Array.Empty<WeatherForecast>();

    }

    public async Task<WeatherForecast?> GetOne(object id)
    {
        // As exception handling is not implemented, then let then be thrown up.
        return await _client.GetFromJsonAsync<WeatherForecast>($"{_apiResx}/{id}");
    }
}

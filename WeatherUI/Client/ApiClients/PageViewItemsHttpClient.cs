using System.Net.Http.Json;
using WeatherUI.Shared;

namespace WeatherUI.Client.ApiClients;

public class PageViewItemsHttpClientService
{
    private readonly string _apiResx = "/api/pageviewitems";

    private readonly HttpClient _client;


    public PageViewItemsHttpClientService(HttpClient httpClient) => _client = httpClient;


    public async Task<IEnumerable<PageViewItem>> GetForViewAsync(string pageId, string userId)
    {
        // As exception handling is not implemented, then let then be thrown up.
        return await _client.GetFromJsonAsync<PageViewItem[]>($"{_apiResx}/{pageId}/{userId}")
            ?? Array.Empty<PageViewItem>();

    }
}

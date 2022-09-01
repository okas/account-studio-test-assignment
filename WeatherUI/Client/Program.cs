using System.Globalization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using WeatherUI.Client;
using WeatherUI.Client.Helpers;
using WeatherUI.Client.ApiClientServices;


WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

Uri backendBaseUri = new(builder.HostEnvironment.BaseAddress);

builder.Services
    .AddScoped(_ => new HttpClient
    {
        BaseAddress = backendBaseUri
    })
    .AddLocalization();

builder.Services.AddHttpClient<WeatherForecastsHttpClientService>(client => client.BaseAddress = backendBaseUri);
builder.Services.AddHttpClient<PageViewItemsHttpClientService>(client => client.BaseAddress = backendBaseUri);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.PostConfigureAll<ClientConfig>(myOptions =>
{
    string path = $"{nameof(ClientConfig)}:{nameof(ClientConfig.SupportedCultures)}";

    myOptions.SupportedCultures = builder.Configuration[path]?
        .Split(",")
        .Select(c => new CultureInfo(c)).ToList()
        ?? new List<CultureInfo>();
});

WebAssemblyHost host = builder.Build();

IJSRuntime jsInterop = host.Services.GetRequiredService<IJSRuntime>();
string appLanguage = await jsInterop.InvokeAsync<string>("appCulture.get");

if (appLanguage != null)
{
    CultureInfo cultureInfo = new(appLanguage);
    CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
    CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
}

await host.RunAsync();


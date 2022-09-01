using System.Globalization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using WeatherUI.Client;
using WeatherUI.Client.Helpers;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services
    .AddScoped(sp => new HttpClient { BaseAddress = new(builder.HostEnvironment.BaseAddress) })
    .AddLocalization();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.PostConfigureAll<ClientConfig>(myOptions =>
{
    string path = $"{nameof(ClientConfig)}:{nameof(ClientConfig.SupportedCultures)}";

    myOptions.SupportedCultures = builder.Configuration[path]?
        .Split(",")
        .Select(c => new CultureInfo(c)).ToList()
        ?? new List<CultureInfo>();
    ;
});

IJSRuntime jsInterop = builder.Build().Services.GetRequiredService<IJSRuntime>();
string appLanguage = await jsInterop.InvokeAsync<string>("appCulture.get");

if (appLanguage != null)
{
    CultureInfo cultureInfo = new(appLanguage);
    CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
    CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
}

await builder.Build().RunAsync();

using System.Globalization;

namespace WeatherUI.Client.Helpers;

public class ClientConfig
{
    public IList<CultureInfo> SupportedCultures { get; set; } = Array.Empty<CultureInfo>();
}

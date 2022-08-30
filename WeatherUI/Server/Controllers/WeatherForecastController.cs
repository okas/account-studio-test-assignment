using Microsoft.AspNetCore.Mvc;
using WeatherUI.Shared;

namespace WeatherUI.Server.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class WeatherForecastsController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet]
    public IEnumerable<WeatherForecast> GetAll()
    {
        return Enumerable.Range(1, 15)
            .Select(CreateWeatherForecast)
            .ToList();
    }

    [HttpGet("{date}")]
    public WeatherForecast GetByDate(DateTime date)
    {
        // TODO: temporal solution for reusability only.
        TimeSpan diff = date - DateTime.Today;

        return CreateWeatherForecast(diff.Days);
    }

    private static WeatherForecast CreateWeatherForecast(int index)
    {
        return new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };
    }
}

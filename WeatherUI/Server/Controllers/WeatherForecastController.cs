using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherUI.Server.DAL;
using WeatherUI.Shared;

namespace WeatherUI.Server.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class WeatherForecastsController : ControllerBase
{
    private readonly ApiDbContext _dbContext;

    public WeatherForecastsController(ApiDbContext dbContext) => _dbContext = dbContext;


    //private static readonly string[] Summaries = new[]
    //{
    //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //};

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> GetAll()
    {
        return await _dbContext.WeatherForecasts.ToListAsync();
    }

    //[HttpGet("{date}")]
    //public WeatherForecast GetByDate(DateTime date)
    //{
    //    // TODO: temporal solution for reusability only.
    //    TimeSpan diff = date - DateTime.Today;

    //    return CreateWeatherForecast(diff.Days);
    //}

    //private static WeatherForecast CreateWeatherForecast(int index)
    //{
    //    return new WeatherForecast

    //    {
    //        Id = Guid.NewGuid(),
    //        Date = DateTime.Now.AddDays(index),
    //        TemperatureC = Random.Shared.Next(-20, 55),
    //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //    };
    //}

}

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


    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> GetAll()
    {
        return await _dbContext.WeatherForecasts.ToListAsync();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<WeatherForecast>> GetById(Guid id, CancellationToken ct)
    {
        return await _dbContext.WeatherForecasts
            .AsNoTracking()
            .SingleOrDefaultAsync(m => m.Id == id, ct).ConfigureAwait(false) is WeatherForecast model
            ? Ok(model)
            : NotFound();
    }
}

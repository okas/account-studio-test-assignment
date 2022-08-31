using Microsoft.EntityFrameworkCore;
using WeatherUI.Shared;

namespace WeatherUI.Server.DAL.EF;

public class ApiDbContext : DbContext
{
	public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
	{ }

	public DbSet<WeatherForecast>? WeatherForecasts { get; set; } = default!;
}

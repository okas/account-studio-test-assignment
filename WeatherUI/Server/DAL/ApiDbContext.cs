using Microsoft.EntityFrameworkCore;
using WeatherUI.Server.DAL.Schema;
using WeatherUI.Shared;

namespace WeatherUI.Server.DAL;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new WeatherForecastSchema());
    }


    public DbSet<WeatherForecast> WeatherForecasts { get; set; } = default!;
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherUI.Server.DAL;
using WeatherUI.Shared;

namespace WeatherUI.Server.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class PageViewItemsController : ControllerBase
{
    private readonly ApiDbContext _dbContext;


    public PageViewItemsController(ApiDbContext dbContext) => _dbContext = dbContext;


    [HttpGet("{pageId}/{userId}")]
    public async Task<IEnumerable<PageViewItem>> GetByUserAndView(string pageId, string userId, CancellationToken ct)
    {
        return await _dbContext.PageViewItems.AsNoTracking()
            .Where(p => p.PageId == pageId && p.UserId == userId)
            .ToListAsync(ct).ConfigureAwait(false);
    }
}

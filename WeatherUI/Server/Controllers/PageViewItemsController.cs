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

    [HttpPost]
    public async Task<ActionResult<IEnumerable<PageViewItem>>> CreateControlsState(IEnumerable<PageViewItem> newModels, CancellationToken ct)
    {
        await _dbContext.PageViewItems.AddRangeAsync(newModels, ct);

        await _dbContext.SaveChangesAsync(ct);

        return Ok(newModels);

    }

    [HttpPut]
    public async Task<IActionResult> UpdateControls(IEnumerable<PageViewItemPatchDto> changeSet, CancellationToken ct)
    {
        foreach (PageViewItemPatchDto dto in changeSet)
        {
            if (await _dbContext.PageViewItems.FindAsync(new object?[] { dto.Id }, cancellationToken: ct) is not PageViewItem entity)
            {
                return NotFound(new { message = $"Update transaction canceled, entity not found: ${dto.Id}" });
            }

            _dbContext.Entry(entity).CurrentValues.SetValues(dto);
        }

        try
        {
            await _dbContext.SaveChangesAsync(ct);
        }
        catch
        {
            return BadRequest();
        }

        return NoContent();
    }
}

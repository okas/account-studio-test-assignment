namespace WeatherUI.Shared;

public class PageViewItem
{
    public Guid Id { get; set; }

    public int Index { get; set; }

    public string Name { get; set; } = default!;

    public bool Selected { get; set; }

    public string PageId { get; set; } = default!;

    public string UserId { get; set; } = default!;
}

namespace WeatherUI.Shared;

public class PageViewItem
{
    public Guid Id { get; set; }
    /// <summary>
    /// Index for filed ordering.
    /// </summary>
    public int Index { get; set; }
    /// <summary>
    /// Name of the objects's property of viewmodel's type.
    /// </summary>
    public string Name { get; set; } = default!;
    /// <summary>
    /// Visibility control.
    /// </summary>
    public bool Selected { get; set; }
    /// <summary>
    /// Page, where instance belongs.
    /// </summary>
    public string PageId { get; set; } = default!;
    /// <summary>
    /// User to who instance belongs.
    /// </summary>
    public string UserId { get; set; } = default!;
}

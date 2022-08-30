namespace WeatherUI.Client.Helpers;

/// <summary>
/// Represents metadata for one filed of tabular data.
/// </summary>
record Field()
{
    /// <summary>
    /// Index for filed ordering.
    /// </summary>
    public int Index { get; set; } = 0;
    /// <summary>
    /// Name of the objects's property of viewmodel's type.
    /// </summary>
    public string Name { get; set; } = "";
    /// <summary>
    /// Display name of filed in table or grid.
    /// </summary>
    public string DisplayName { get; set; } = "";
    /// <summary>
    /// Visibility control.
    /// </summary>
    public bool Selected { get; set; } = true;
};

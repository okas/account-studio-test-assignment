namespace WeatherUI.Shared;

/// <summary>
/// DTO for change info transfer to API.
/// </summary>
/// <param name="Id"></param>
/// <param name="Index"></param>
/// <param name="Selected"></param>
public record PageViewItemPatchDto(Guid Id, int Index, bool Selected);

namespace Bitstore.DTO.Beat;

public record BeatResponse(string Title, decimal Price, string AudioUrl,
    string? Description, string? CoverUrl);
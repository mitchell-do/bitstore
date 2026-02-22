namespace Bitstore.DTO.Beat;

public record BeatRequest(string Title, decimal Price,
    string AudioUrl);
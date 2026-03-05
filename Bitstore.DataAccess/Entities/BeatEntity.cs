using Bitstore.Core.Models;

namespace Bitstore.DataAccess.Entities;

public class BeatEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price  { get; set; }
    public string AudioUrl { get; set; } = string.Empty;
    public bool IsPublished { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid UserId { get; set; }
    public UserEntity User { get; set; } = null!;
}
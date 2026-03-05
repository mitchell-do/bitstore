namespace Bitstore.Core.Models;

public class Beat
{
    public Beat(Guid id, string title, decimal price, string audioUrl, bool isPublished, User user, Guid userId)
    {
        Id = id;
        Title = title;
        Price = price;
        AudioUrl = audioUrl;
        IsPublished = isPublished;
        User = user;
        UserId = userId;
        CreatedAt = DateTime.UtcNow.Date;
    }
    public Guid Id { get; }
    public string Title { get; }
    public decimal Price  { get; }
    public string AudioUrl { get; }
    public bool IsPublished { get; }
    public DateTime CreatedAt { get; }
    public Guid UserId { get; }
    public User User { get; }

    public static Beat Create(Guid id, string title, decimal price,
        string audioUrl, bool isPublished,  User user,  Guid userId)
    {
        //there will be a validation
        if (string.IsNullOrEmpty(title))
        {
            throw new Exception();
        }
        var beat = new Beat(id, title, price, audioUrl, isPublished,  user, userId);
        return beat;
    }
}
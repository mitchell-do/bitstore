namespace Bitstore.Core.Models;

public class Beat
{
    private readonly List<License> _licenses = new();
    private readonly List<OrderItem> _orderItems = new();
    
    private Beat(string title, decimal price, string audioUrl,bool isPublished, 
        string? description, string? coverUrl, User user)
    {
        Id = Guid.NewGuid();
        Title = title;
        Price = price;
        AudioUrl = audioUrl;
        CoverUrl = coverUrl;
        Description = description;
        IsPublished = isPublished;
        User = user;
        UserId = user.Id;
        CreatedAt = DateTime.UtcNow;
    }
    public Guid Id { get; }
    public string Title { get; }
    public decimal Price  { get; }
    public string? Description { get; }
    public string AudioUrl { get; }
    public string? CoverUrl { get; } //обложка
    public bool IsPublished { get; }
    public DateTime CreatedAt { get; }
    public Guid UserId { get; }
    public User User { get; }
    
    public IReadOnlyCollection<License> Licenses =>  _licenses;
    public IReadOnlyCollection<OrderItem> OrderItems =>  _orderItems;
    
    
    public static Beat Create(string title, decimal price,
        string audioUrl, bool isPublished, string? description, string? coverUrl,  User user)
    {
        //there will be a validation
        if (string.IsNullOrEmpty(title) ||  string.IsNullOrEmpty(audioUrl))
            throw new Exception();
        if (user == null)
            throw new ArgumentNullException();
        
        var beat = new Beat(title, price, audioUrl, isPublished, description, coverUrl, user);
        return beat;
    }

    public void AddLicense(License license)
    {
        if (license == null)
            throw new ArgumentNullException();
        
        _licenses.Add(license);
    }

    public void AddOrderItem(OrderItem orderItem)
    {
        if (orderItem == null)
            throw new ArgumentNullException();
        _orderItems.Add(orderItem);
    }
}
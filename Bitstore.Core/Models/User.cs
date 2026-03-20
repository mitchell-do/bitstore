using Bitstore.Core.Enums;

namespace Bitstore.Core.Models;

public class User
{
    private readonly List<Beat> _beats = new();
    private readonly List<Order> _orders = new();
    private readonly List<OrderItem> _orderItems = new();
    private User(Guid userId, string username,
        string email, string passwordHash, string role)
    {
        Id = userId;
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
    }
    public Guid  Id { get; }
    public string Username { get;  }
    public string Email { get;  }
    public string Role { get; } 
    public string PasswordHash { get;  }
    public decimal Balance { get; } = 0;
    
    public IReadOnlyCollection<Beat> Beats => _beats;
    public IReadOnlyCollection<Order> Orders => _orders;
    public IReadOnlyCollection<OrderItem> SoldItems => _orderItems;
    
    public static  User Create(Guid userId, string username, 
        string email, string passwordHash, string role)
    {
        // validation
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(passwordHash))
        {
            throw new ArgumentNullException();
        }
        return new User(userId, username, email, passwordHash, role);
    }

    public void AddBeat(Beat beat)
    {
        if (beat == null)
            throw new ArgumentNullException();
        _beats.Add(beat);
    }

    public void AddOrder(Order order)
    {
        if (order == null)
            throw new ArgumentNullException();
        _orders.Add(order);
    }

    public void AddOrderItem(OrderItem orderItem)
    {
        if (orderItem == null)
            throw new ArgumentNullException();
        _orderItems.Add(orderItem);
    }
}
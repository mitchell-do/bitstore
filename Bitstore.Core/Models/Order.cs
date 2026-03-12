using Bitstore.Core.Enums;

namespace Bitstore.Core.Models;

public class Order
{
    private readonly List<OrderItem> _items = new();
    private Order(User user, decimal totalAmount)
    {
        Id = Guid.NewGuid();
        Buyer = user;
        BuyerId = user.Id;
        CreatedAt = DateTime.UtcNow;
        TotalAmount = totalAmount;
    }
    public Guid Id { get;  }
    public string OrderNumber { get;  } = string.Empty;
    public Guid BuyerId { get;  }
    public User Buyer { get;  }
    public decimal TotalAmount { get;  }
    public OrderStatus Status { get;  } = OrderStatus.Pending;
    public DateTime CreatedAt { get;  }
    public IReadOnlyCollection<OrderItem> Items => _items;

    public void AddItem(OrderItem item)
    {
        if (item == null)
            throw new ArgumentNullException();
        _items.Add(item);
    }
}
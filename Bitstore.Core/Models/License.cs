using Bitstore.Core.Enums;

namespace Bitstore.Core.Models;

// 3 лицензии на бит = бизнес-логика маркетплейса
public class License
{
    private readonly List<OrderItem> _orderItems = new();

    private License(LicenseType type, string name,  decimal price, Beat beat )
    {
        Id =  Guid.NewGuid();
        Name = name;
        Type = type;
        Price = price;
        Beat = beat;
        BeatId = beat.Id;
    }
    public Guid Id { get;  }
    public LicenseType Type { get;  }
    public string Name { get;  }
    public decimal Price { get;  }
    public Guid BeatId { get;  }
    public Beat Beat { get;  }
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
    
    public void AddItem(OrderItem item)
    {
        if (item == null) 
            throw new ArgumentNullException(nameof(item));
        _orderItems.Add(item);
    }
}
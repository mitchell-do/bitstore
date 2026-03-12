namespace Bitstore.Core.Models;

public class OrderItem
{
    private OrderItem(decimal price, Order order, Beat beat,
        License license, User seller)
    {
        Id =  Guid.NewGuid();
        Price = price;
        Order = order;
        OrderId = order.Id;
        BeatId = beat.Id;
        Beat = beat;
        License = license;
        LicenseId = license.Id;
        Seller = seller;
        SellerId = seller.Id;
    }
    
    public Guid Id { get;  }
    public decimal Price { get;  }
    
    public Guid OrderId { get;  }
    public Order Order { get;  }
    
    public Guid BeatId { get;  }
    public Beat Beat { get;  }
    
    public Guid LicenseId { get;  }
    public License License { get;  }
    
    public Guid SellerId { get;  }
    public User Seller { get;  }
    
}
using Bitstore.Core.Enums;
using Bitstore.Core.Models;

namespace Bitstore.DataAccess.Entities;

public class OrderEntity
{
    public Guid Id { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public Guid BuyerId { get; set; }
    public UserEntity Buyer { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; } 
    public DateTime CreatedAt { get; set; }
    public List<OrderItemEntity> Items { get; set; } = new();
}
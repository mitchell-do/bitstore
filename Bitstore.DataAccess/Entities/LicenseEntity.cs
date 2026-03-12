using Bitstore.Core.Enums;

namespace Bitstore.DataAccess.Entities;

public class LicenseEntity
{
    public Guid Id { get; set; }
    public LicenseType Type { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Guid BeatId { get; set; }
    public BeatEntity Beat { get; set; }
    public List<OrderItemEntity> OrderItems { get; set; } = new();
}
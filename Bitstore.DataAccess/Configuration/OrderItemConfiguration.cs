using Bitstore.Core.Models;
using Bitstore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitstore.DataAccess.Configuration;

public class OrderItemConfiguration: IEntityTypeConfiguration<OrderItemEntity>
{
    public void Configure(EntityTypeBuilder<OrderItemEntity> builder)
    {
        builder.HasKey(i => i.Id);
        builder.HasOne(i => i.Beat)
            .WithMany(b => b.Items);
        builder.HasOne(i => i.Seller)
            .WithMany(u => u.Items);
        builder.HasOne(i => i.Order)
            .WithMany(o => o.Items);
        builder.HasOne(i => i.License)
            .WithMany(l => l.OrderItems);
    }
}
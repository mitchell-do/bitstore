using Bitstore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitstore.DataAccess.Configuration;

public class OrderConfiguration: IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.HasKey(o => o.Id);
        builder.HasOne(o => o.Buyer)
            .WithMany(u => u.Orders);
        builder.HasMany(i => i.Items)
            .WithOne(o => o.Order);
        builder.Property(o => o.TotalAmount)
            .IsRequired();
        builder.Property(o => o.OrderNumber)
            .IsRequired();
        builder.Property(o => o.Status)
            .IsRequired();
    }
}
using Bitstore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitstore.DataAccess.Configuration;

public class LicenseConfiguration: IEntityTypeConfiguration<LicenseEntity>
{
    public void Configure(EntityTypeBuilder<LicenseEntity> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Name)
            .IsRequired();
        builder.Property(l => l.Type)
            .IsRequired();
        builder.Property(l => l.Price)
            .IsRequired();
        builder.HasOne(l => l.Beat)
            .WithMany(b => b.Licenses);
        builder.HasMany(l => l.OrderItems)
            .WithOne(i => i.License);
    }
}
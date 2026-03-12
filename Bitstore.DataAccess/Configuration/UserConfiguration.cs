using Bitstore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitstore.DataAccess.Configuration;

public class UserConfiguration: IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder
            .HasMany(b => b.Beats)
            .WithOne(b => b.User);
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Email)
            .IsRequired();
        builder.Property(x => x.Role)
            .IsRequired();
        builder.Property(x => x.Username)
            .IsRequired();
        builder.Property(x => x.Balance)
            .IsRequired();
    }
}
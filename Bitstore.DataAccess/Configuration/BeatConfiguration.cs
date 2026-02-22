using Bitstore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitstore.DataAccess.Configuration;

public class BeatConfiguration: IEntityTypeConfiguration<BeatEntity>
{
    public void Configure(EntityTypeBuilder<BeatEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title)
            .IsRequired();
        builder.Property(x => x.Price)
            .IsRequired();
        builder.Property(x => x.AudioUrl)
            .IsRequired();
    }
}
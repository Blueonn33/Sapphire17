using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sapphire17.Models;
using System.Collections.ObjectModel;

namespace Sapphire17.Data.EntityConfigurations
{
    public class SetEntityConfiguration : IEntityTypeConfiguration<Set>
    {
        public void Configure(EntityTypeBuilder<Set> builder)
        {
            builder.ToTable("Collections");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.ImageData);
            builder.Property(c => c.ImageMimeType);
            builder.Property(c => c.Visible);
            builder.Property(c => c.Favorite);

            builder.HasOne(c => c.User)
                .WithMany(u => u.Sets)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Decks)
                .WithOne(d => d.Set)
                .HasForeignKey(d => d.SetId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

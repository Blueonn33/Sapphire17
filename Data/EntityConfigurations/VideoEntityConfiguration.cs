using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sapphire17.Models;

namespace Sapphire17.Data.EntityConfigurations
{
    public class VideoEntityConfiguration : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.ToTable("Videos");

            builder.HasKey(v => v.Id);
            builder.Property(v => v.Title);
            builder.Property(v => v.Description);
            builder.Property(v => v.Link);
            builder.Property(v => v.ImageData);
            builder.Property(v => v.ImageMimeType);

            builder.HasOne(v => v.User)
                .WithMany(u => u.Videos)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

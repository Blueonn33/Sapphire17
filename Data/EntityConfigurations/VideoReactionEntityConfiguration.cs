using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sapphire17.Models;

namespace Sapphire17.Data.EntityConfigurations
{
    public class VideoReactionEntityConfiguration : IEntityTypeConfiguration<VideoReaction>
    {
        public void Configure(EntityTypeBuilder<VideoReaction> builder)
        {
            builder.ToTable("VideoReactions");

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Reaction).IsRequired().HasMaxLength(10);

            builder.HasOne(v => v.Video)
                .WithMany(vr => vr.VideoReactions)
                .HasForeignKey(v => v.VideoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.User)
                .WithMany()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

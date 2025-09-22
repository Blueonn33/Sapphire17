using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sapphire17.Models;

namespace Sapphire17.Data.EntityConfigurations
{
    public class AdviceEntityConfiguration : IEntityTypeConfiguration<Advice>
    {
        public void Configure(EntityTypeBuilder<Advice> builder)
        {
            builder.ToTable("Advices");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Value).IsRequired().HasMaxLength(300);
            builder.Property(a => a.ImageData);
            builder.Property(a => a.ImageMimeType);
            builder.Property(a => a.Type).IsRequired().HasMaxLength(100);

            builder.HasOne(a => a.User)
                .WithMany(u => u.Advices)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

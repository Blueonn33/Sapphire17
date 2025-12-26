using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sapphire17.Models;

namespace Sapphire17.Data.EntityConfigurations
{
    public class ResultEntityConfiguration : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.ToTable("Results");

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Points).IsRequired();
            builder.Property(r => r.DateAnswered);

            builder.HasOne(r => r.Flashcard)
                .WithMany(f => f.Results)
                .HasForeignKey(r => r.FlashcardId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

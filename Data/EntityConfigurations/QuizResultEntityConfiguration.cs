using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sapphire17.Models;

namespace Sapphire17.Data.EntityConfigurations
{
    public class QuizResultEntityConfiguration : IEntityTypeConfiguration<QuizResult>
    {
        public void Configure(EntityTypeBuilder<QuizResult> builder)
        {
            builder.ToTable("QuizResults");

            builder.HasKey(v => v.Id);
            builder.Property(v => v.Score);
            builder.Property(v => v.TotalScore);
            builder.Property(v => v.DateCompleted);

            builder.HasOne(v => v.QuizCollection)
                .WithMany(u => u.QuizResults)
                .HasForeignKey(u => u.QuizCollectionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(qr => qr.User)
                .WithMany(u => u.QuizResults)
                .HasForeignKey(qr => qr.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

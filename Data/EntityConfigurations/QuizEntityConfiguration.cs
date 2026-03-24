using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sapphire17.Models;

namespace Sapphire17.Data.EntityConfigurations
{
    public class QuizEntityConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.ToTable("Quizzes");

            builder.HasKey(v => v.Id);
            builder.Property(v => v.Question);
            builder.Property(v => v.Answer);

            builder.HasOne(v => v.QuizCollection)
                .WithMany(u => u.Quizzes)
                .HasForeignKey(u => u.QuizCollectionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(q => q.QuizResults)
                .WithOne(qr => qr.Quiz)
                .HasForeignKey(qr => qr.QuizId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

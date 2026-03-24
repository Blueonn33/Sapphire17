
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sapphire17.Models;

namespace Sapphire17.Data.EntityConfigurations
{
    public class QuizCollectionEntityConfiguration : IEntityTypeConfiguration<QuizCollection>
    {
        public void Configure(EntityTypeBuilder<QuizCollection> builder)
        {
            builder.ToTable("QuizCollections");

            builder.HasKey(q => q.Id);
            builder.Property(q => q.Name);
            builder.Property(q => q.Description);
            builder.Property(q => q.ImageData);
            builder.Property(q => q.ImageMimeType);

            builder.HasMany(q => q.Quizzes)
                .WithOne(qc => qc.QuizCollection)
                .HasForeignKey(q => q.QuizCollectionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sapphire17.Models;

namespace Sapphire17.Data.EntityConfigurations
{
    public class FlashcardEntityConfiguration : IEntityTypeConfiguration<Flashcard>
    {
        public void Configure(EntityTypeBuilder<Flashcard> builder)
        {
            builder.ToTable("Flashcards");

            builder.HasKey(f => f.Id);
            builder.Property(f => f.Question).IsRequired().HasMaxLength(200);
            builder.Property(f => f.Answer).IsRequired();

            builder.HasOne(f => f.Deck)
                .WithMany(d => d.Flashcards)
                .HasForeignKey(f => f.DeckId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

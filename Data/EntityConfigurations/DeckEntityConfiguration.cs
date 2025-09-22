using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sapphire17.Models;
using System.Security.Cryptography.Pkcs;

namespace Sapphire17.Data.EntityConfigurations
{
    public class DeckEntityConfiguration : IEntityTypeConfiguration<Deck>
    {
        public void Configure(EntityTypeBuilder<Deck> builder)
        {
            builder.ToTable("Decks");

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Description).IsRequired().HasMaxLength(500);
            builder.Property(d => d.ImageData);
            builder.Property(d => d.ImageMimeType);
            builder.Property(d => d.Visible);

            builder.HasOne(d => d.Set)
                .WithMany(s => s.Decks)
                .HasForeignKey(d => d.SetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(d => d.Flashcards)
                .WithOne(f => f.Deck)
                .HasForeignKey(f => f.DeckId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

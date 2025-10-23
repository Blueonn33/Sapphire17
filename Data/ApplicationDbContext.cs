using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sapphire17.Areas.Identity.Data;
using Sapphire17.Data.EntityConfigurations;
using Sapphire17.Models;

namespace Sapphire17.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Advice> Advices { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<Flashcard> Flashcards { get; set; }
        public DbSet<Note> Notes { get; set; } 
        public DbSet<Set> Sets { get; set; }
        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AdviceEntityConfiguration());
            builder.ApplyConfiguration(new DeckEntityConfiguration());
            builder.ApplyConfiguration(new FlashcardEntityConfiguration());
            builder.ApplyConfiguration(new NoteEntityConfiguration());
            builder.ApplyConfiguration(new SetEntityConfiguration());
            builder.ApplyConfiguration(new VideoEntityConfiguration());
        }
    }
}

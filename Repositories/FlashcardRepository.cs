using Microsoft.EntityFrameworkCore;
using Sapphire17.Data;
using Sapphire17.Models;
using Sapphire17.Repositories.Interfaces;

namespace Sapphire17.Repositories
{
    public class FlashcardRepository : IFlashcardRepository
    {
        private readonly ApplicationDbContext _context;

        public FlashcardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Flashcard>> GetAllFlashcardsByDeckIdAsync(int deckId)
        {
            if(deckId == 0)
            {
                throw new ArgumentNullException(nameof(deckId));
            }

            var flashcards = await _context.Flashcards.Where(f => f.DeckId == deckId).ToListAsync();
            return flashcards;
        }

        public async Task<Flashcard?> GetFlashcardByIdAsync(int id)
        {
            if(id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var flashcard = await _context.Flashcards.FindAsync(id);
            return flashcard;
        }

        public async Task CreateFlashcardAsync(Flashcard flashcard)
        {
            if(flashcard == null)
            {
                throw new ArgumentNullException(nameof(flashcard));
            }

            await _context.Flashcards.AddAsync(flashcard);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFlashcardAsync(Flashcard flashcard)
        {
            if (flashcard == null)
            {
                throw new ArgumentNullException(nameof(flashcard));
            }

            _context.Flashcards.Update(flashcard);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFlashcardAsync(int id)
        {
            if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
        }
    }
}

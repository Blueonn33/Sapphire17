using Microsoft.EntityFrameworkCore;
using Sapphire17.Data;
using Sapphire17.Models;
using Sapphire17.Repositories.Interfaces;

namespace Sapphire17.Repositories
{
    public class DeckRepository : IDeckRepository
    {
        private readonly ApplicationDbContext _context;

        public DeckRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Deck>> GetAllDecksBySetIdAsync(int setId)
        {
            if(setId == 0)
            {
                throw new ArgumentNullException(nameof(setId));
            }

            var decks = await _context.Decks.Where(s => s.Id == setId).ToListAsync();
            return decks;
        }

        public async Task<Deck?> GetDeckByIdAsync(int deckId)
        {
            if (deckId == 0)
            {
                throw new ArgumentNullException(nameof(deckId));
            }

            var deck = await _context.Decks.FindAsync(deckId);
            return deck;
        }

        public async Task CreateDeckAsync(Deck deck)
        {
            if(deck == null)
            {
                throw new ArgumentNullException(nameof(deck));
            }

            await _context.Decks.AddAsync(deck);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDeckAsync(Deck deck)
        {
            if (deck == null)
            {
                throw new ArgumentNullException(nameof(deck));
            }

            _context.Decks.Update(deck);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDeckAsync(int deckId)
        {
            var deck = await _context.Decks.FindAsync(deckId);
            _context.Decks.Remove(deck);
            await _context.SaveChangesAsync();
        }
    }
}

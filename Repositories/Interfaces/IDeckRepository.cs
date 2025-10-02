using Sapphire17.Models;

namespace Sapphire17.Repositories.Interfaces
{
    public interface IDeckRepository
    {
        public Task<IEnumerable<Deck>> GetAllDecksBySetIdAsync(int setId);
        public Task<Deck?> GetDeckByIdAsync(int deckId);
        public Task CreateDeckAsync(Deck deck);
        public Task UpdateDeckAsync(Deck deck);
        public Task DeleteDeckAsync(int deckId);
    }
}

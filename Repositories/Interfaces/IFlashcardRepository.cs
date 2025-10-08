
using Sapphire17.Models;

namespace Sapphire17.Repositories.Interfaces
{
    public interface IFlashcardRepository
    {
        public Task<IEnumerable<Flashcard>> GetAllFlashcardsByDeckIdAsync(int deckId);
        public Task<Flashcard?> GetFlashcardByIdAsync(int id);
        public Task CreateFlashcardAsync(Flashcard flashcard);
        public Task UpdateFlashcardAsync(Flashcard flashcard);
        public Task DeleteFlashcardAsync(int id);
    }
}

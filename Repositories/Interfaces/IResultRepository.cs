using Sapphire17.Data;
using Sapphire17.Models;

namespace Sapphire17.Repositories.Interfaces
{
    public interface IResultRepository
    {
        //public Task<IEnumerable<Result>> GetAllResultsByDeckIdAsync(int deckId);
        public Task<IEnumerable<Result>> GetAllResultsByFlashcardIdAsync(int flashcardId);
        public Task<Result?> GetResultByFlashcardIdAsync(int flashcardId);
        public Task<Result?> GetResultByIdAsync(int resultId);
        public Task CreateResultAsync(Result result);
        public Task DeleteResultAsync(int resultId);
    }
}

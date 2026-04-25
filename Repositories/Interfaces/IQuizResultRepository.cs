using Sapphire17.Models;

namespace Sapphire17.Repositories.Interfaces
{
    public interface IQuizResultRepository
    {
        public Task<IEnumerable<QuizResult>> GetQuizResultByQuizCollectionAndUser(int quizCollectionId, string userId);
        public Task<QuizResult?> GetQuizResultById(int quizResultId);
        public Task CreateQuizResult(QuizResult quizResult);
    }
}

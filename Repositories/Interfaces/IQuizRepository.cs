using Sapphire17.Models;

namespace Sapphire17.Repositories.Interfaces
{
    public interface IQuizRepository
    {
        public Task<IEnumerable<Quiz>> GetAllQuizzesAsync(int quizCollectionId);
        public Task<Quiz?> GetQuizByIdAsync(int quizId);
        public Task CreateQuiz(Quiz quiz);
        public Task UpdateQuiz(Quiz quiz);
        public Task DeleteQuiz(int quizId);
    }
}

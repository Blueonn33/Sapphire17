using Sapphire17.Models;

namespace Sapphire17.Repositories.Interfaces
{
    public interface IQuizCollectionRepository
    {
        public Task<IEnumerable<QuizCollection>> GetAllQuizCollections();
        public Task<QuizCollection?> GetQuizCollectionById(int quizCollectionId);
        public Task CreateQuizCollection(QuizCollection quizCollection);
        public Task UpdateQuizCollection(QuizCollection quizCollection);
        public Task DeleteQuizCollection(int quizCollectionId);
    };
}

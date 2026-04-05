using Sapphire17.Models;
using Sapphire17.Repositories.Interfaces;

namespace Sapphire17.Repositories
{
    public class QuizCollectionRepository : IQuizCollectionRepository
    {
        public Task CreateQuizCollection(QuizCollection quizCollection)
        {
            throw new NotImplementedException();
        }

        public Task DeleteQuizCollection(int quizCollectionId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<QueryCollection>> GetAllQuizCollections()
        {
            throw new NotImplementedException();
        }

        public Task<QuizCollectionRepository?> GetQuizCollectionById(int quizCollectionId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateQuizCollection(QuizCollection quizCollection)
        {
            throw new NotImplementedException();
        }
    }
}

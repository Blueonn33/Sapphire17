using Microsoft.EntityFrameworkCore;
using Sapphire17.Data;
using Sapphire17.Models;
using Sapphire17.Repositories.Interfaces;

namespace Sapphire17.Repositories
{
    public class QuizCollectionRepository : IQuizCollectionRepository
    {
        private readonly ApplicationDbContext _context;

        public QuizCollectionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateQuizCollection(QuizCollection quizCollection)
        {
            if (quizCollection == null)
            {
                throw new ArgumentNullException(nameof(quizCollection));
            }

            await _context.QuizCollections.AddAsync(quizCollection);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuizCollection(int quizCollectionId)
        {
            var quizCollection = await _context.QuizCollections.FindAsync(quizCollectionId);

            if (quizCollection == null)
            {
                throw new ArgumentNullException(nameof(quizCollection));
            }

            _context.QuizCollections.Remove(quizCollection);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<QuizCollection>> GetAllQuizCollections()
        {
            return await _context.QuizCollections.ToListAsync();
        }

        public async Task<QuizCollection?> GetQuizCollectionById(int quizCollectionId)
        {
            var quizCollection = await _context.QuizCollections.FindAsync(quizCollectionId);

            if (quizCollection == null)
            {
                throw new ArgumentNullException(nameof(quizCollection));
            }

            return quizCollection;
        }

        public Task UpdateQuizCollection(QuizCollection quizCollection)
        {
            throw new NotImplementedException();
        }
    }
}

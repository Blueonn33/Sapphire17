using Microsoft.EntityFrameworkCore;
using Sapphire17.Data;
using Sapphire17.Models;
using Sapphire17.Repositories.Interfaces;

namespace Sapphire17.Repositories
{
    public class QuizResultRepository : IQuizResultRepository
    {
        private readonly ApplicationDbContext _context;

        public QuizResultRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuizResult>> GetQuizResultByQuizCollectionAndUser(int quizCollectionId, string userId)
        {
            var quizResult = await _context.QuizResults
                .Where(q => q.QuizCollectionId == quizCollectionId && q.UserId == userId)
                .OrderByDescending(q => q.DateCompleted)
                .ToListAsync();

            return quizResult;
        }

        public async Task<QuizResult?> GetQuizResultById(int quizResultId)
        {
            var quizResult = await _context.QuizResults.FindAsync(quizResultId);
            return quizResult;
        }

        public async Task CreateQuizResult(QuizResult quizResult)
        {
            await _context.QuizResults.AddAsync(quizResult);
            await _context.SaveChangesAsync();
        }
    }
}

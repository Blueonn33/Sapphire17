using Microsoft.EntityFrameworkCore;
using Sapphire17.Data;
using Sapphire17.Models;
using Sapphire17.Repositories.Interfaces;

namespace Sapphire17.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly ApplicationDbContext _context;

        public QuizRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateQuiz(Quiz quiz)
        {
            if (quiz == null)
            {
                throw new ArgumentNullException(nameof(quiz));
            }

            await _context.Quizzes.AddAsync(quiz);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuiz(int quizId)
        {
            var quiz = await _context.Quizzes.FindAsync(quizId);

            if (quiz == null)
            {
                throw new ArgumentNullException(nameof(quiz));
            }

            _context.Quizzes.Remove(quiz);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Quiz>> GetAllQuizzesAsync()
        {
            return await _context.Quizzes.ToListAsync();
        }

        public async Task<Quiz?> GetQuizByIdAsync(int quizId)
        {
            var quiz = await _context.Quizzes.FindAsync(quizId);

            if (quiz == null)
            {
                throw new ArgumentNullException(nameof(quiz));
            }

            return quiz;
        }

        public Task UpdateQuiz(Quiz quiz)
        {
            throw new NotImplementedException();
        }
    }
}

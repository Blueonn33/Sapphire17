using System.Net.Mime;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Sapphire17.Data;
using Sapphire17.Models;
using Sapphire17.Repositories.Interfaces;

namespace Sapphire17.Repositories
{
    public class ResultRepository : IResultRepository
    {
        private readonly ApplicationDbContext _context;

        public ResultRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateResultAsync(Result result)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            await _context.Results.AddAsync(result);
            _context.SaveChanges();
        }

        public async Task DeleteResultAsync(int resultId)
        {
            if (resultId == 0)
            {
                throw new ArgumentNullException(nameof(resultId));
            }

            var result = await _context.Results.FindAsync(resultId);
            _context.Results.Remove(result);
            _context.SaveChanges();
        }

        //public async Task<IEnumerable<Result>> GetAllResultsByDeckIdAsync(int deckId)
        //{
        //    if (deckId == 0)
        //    {
        //        throw new ArgumentNullException(nameof(deckId));
        //    }

        //    return await _context.Results
        //        .Include(r => r.Flashcard)
        //        .Where(r => r.Flashcard.DeckId == deckId)
        //        .ToListAsync();
        //}

        public async Task<IEnumerable<Result>> GetAllResultsByFlashcardIdAsync(int flashcardId)
        {
            if (flashcardId == 0)
            {
                throw new ArgumentNullException(nameof(flashcardId));
            }

            return await _context.Results
                .Where(r => r.FlashcardId == flashcardId)
                .OrderByDescending(r => r.DateAnswered)
                .ToListAsync();
        }

        public async Task<Result?> GetResultByFlashcardIdAsync(int flashcardId)
        {
            if (flashcardId == 0)
            {
                throw new ArgumentNullException(nameof(flashcardId));
            }

            var result = await _context.Results
                .FirstOrDefaultAsync(r => r.FlashcardId == flashcardId);

            return result;
        }

        public Task<Result?> GetResultByIdAsync(int resultId)
        {
            if (resultId == 0)
            {
                throw new ArgumentNullException(nameof(resultId));
            }

            var result = _context.Results
                .FirstOrDefaultAsync(r => r.Id == resultId);

            return result;
        }
    }
}

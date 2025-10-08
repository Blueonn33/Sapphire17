using Microsoft.EntityFrameworkCore;
using Sapphire17.Data;
using Sapphire17.Models;
using Sapphire17.Repositories.Interfaces;

namespace Sapphire17.Repositories
{
    public class AdviceRepository : IAdviceRepository
    {
        private readonly ApplicationDbContext _context;

        public AdviceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Advice>> GetAllAdvicesByUserIdAsync(string userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var advices = await _context.Advices.Where(a => a.UserId == userId).ToListAsync();
            return advices;
        }

        public async Task<Advice?> GetAdviceByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var advice = await _context.Advices.FindAsync(id);
            return advice;
        }

        public async Task CreateAdviceAsync(Advice advice)
        {
            if (advice == null)
            {
                throw new ArgumentNullException(nameof(advice));
            }

            await _context.Advices.AddAsync(advice);
            _context.SaveChanges();
        }

        public async Task UpdateAdviceAsync(Advice advice)
        {
            if (advice == null)
            {
                throw new ArgumentNullException(nameof(advice));
            }

            _context.Advices.Update(advice);
            _context.SaveChanges();
        }

        public async Task DeleteAdviceAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var advice = await _context.Advices.FindAsync(id);
            _context.Advices.Remove(advice);
            _context.SaveChanges();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Sapphire17.Data;
using Sapphire17.Models;
using Sapphire17.Repositories.Interfaces;

namespace Sapphire17.Repositories
{
    public class SetRepository : ISetRepository
    {
        private readonly ApplicationDbContext _context;

        public SetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Set>> GetAllSetsByUserIdAsync(string userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var sets = await _context.Sets.ToListAsync();
            return sets;
        }

        public async Task<Set?> GetSetByIdAsync(int setId)
        {
            if (setId == 0)
            {
                throw new ArgumentNullException(nameof(setId));
            }

            var set = await _context.Sets.FindAsync(setId);
            return set;
        }

        public async Task CreateSetAsync(Set set)
        {
            if (set == null)
            {
                throw new ArgumentNullException(nameof(set));
            }

            if (_context.Sets.Contains(set))
            {
                throw new Exception("Set already exists");
            }
            else
            {
                _context.Sets.Add(set);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateSetAsync(Set set)
        {
            if (set != null)
            {
                _context.Sets.Update(set);
                await _context.SaveChangesAsync();
            }
        }
        
        public async Task DeleteSetAsync(int setId)
        {
            if(setId == 0)
            {
                throw new ArgumentNullException(nameof(setId));
            }

            var set = await _context.Sets.FindAsync(setId);

            if (set == null)
            {
                throw new Exception("Set not found");
            }

            _context.Remove(set);
            await _context.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Sapphire17.Data;
using Sapphire17.Models;
using Sapphire17.Repositories.Interfaces;

namespace Sapphire17.Repositories
{
    public class VideoReactionRepository : IVideoReactionRepository
    {
        private readonly ApplicationDbContext _context;

        public VideoReactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VideoReaction>> GetAllReactionsByVideoIdAsync(int videoId)
        {
            if (videoId == 0)
            {
                throw new Exception("Video not found");
            }

            var reactions = await _context.VideoReactions
                .Where(v => v.VideoId == videoId)
                .ToListAsync();

            return reactions;
        }

        public async Task<VideoReaction?> GetReactionByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new Exception("Reaction not found");
            }

            var reaction = await _context.VideoReactions.Include(v => v.Video)
                .FirstOrDefaultAsync(d => d.Id == id);

            return reaction;
        }

        public async Task CreateReactionAsync(VideoReaction videoReaction)
        {
            if (videoReaction == null)
            {
                throw new Exception("Reaction not found");
            }

            await _context.AddAsync(videoReaction);
            await _context.SaveChangesAsync();
        }

        public Task UpdateReactionAsync(VideoReaction videoReaction)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReactionAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

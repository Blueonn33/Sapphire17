using Microsoft.EntityFrameworkCore;
using Sapphire17.Data;
using Sapphire17.Models;
using Sapphire17.Repositories.Interfaces;

namespace Sapphire17.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly ApplicationDbContext _context;

        public VideoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Video>> GetAllVideosByUserIdAsync(string userId)
        {
            if(userId == null)
            {
                throw new ArgumentNullException(nameof(userId));    
            }

            var videos = await _context.Videos.Where(v => v.UserId == userId).ToListAsync();
            return videos;
        }

        public async Task<Video?> GetVideoByIdAsync(int id)
        {
            if(id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var video = await _context.Videos.FindAsync(id);
            return video;
        }

        public async Task CreateVideoAsync(Video video)
        {
            if (video == null)
            {
                throw new ArgumentNullException(nameof(video));
            }

            await _context.Videos.AddAsync(video);
            _context.SaveChanges();
        }

        public async Task UpdateVideoAsync(Video video)
        {
            if (video == null)
            {
                throw new ArgumentNullException(nameof(video));
            }

            _context.Videos.Update(video);
            _context.SaveChanges();
        }

        public async Task DeleteVideoAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var video = await _context.Videos.FindAsync(id);
            _context.Videos.Remove(video);
            _context.SaveChanges();
        }
    }
}

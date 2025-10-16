using Sapphire17.Models;

namespace Sapphire17.Repositories.Interfaces
{
    public interface IVideoRepository
    {
        public Task<IEnumerable<Video>> GetAllVideosByUserIdAsync(string userId);
        public Task<Video?> GetVideoByIdAsync(int id);
        public Task CreateVideoAsync(Video video);
        public Task UpdateVideoAsync(Video video);
        public Task DeleteVideoAsync(int id);
    }
}

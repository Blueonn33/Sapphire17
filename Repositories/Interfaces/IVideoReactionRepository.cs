using Sapphire17.Models;

namespace Sapphire17.Repositories.Interfaces
{
    public interface IVideoReactionRepository
    {
        public Task<IEnumerable<VideoReaction>> GetAllReactionsByVideoIdAsync(int videoId);
        public Task<VideoReaction?> GetReactionByIdAsync(int id);
        public Task CreateReactionAsync(VideoReaction videoReaction);
        public Task<VideoReaction?> GetUserReactionAsync(string userId, int videoId);
        public Task<int> CountReactions(int videoId, string reactionType);
        public Task UpdateReactionAsync(VideoReaction videoReaction);
        public Task DeleteReactionAsync(int id);
    }
}

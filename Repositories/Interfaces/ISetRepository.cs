using Sapphire17.Models;

namespace Sapphire17.Repositories.Interfaces
{
    public interface ISetRepository
    {
        public Task<IEnumerable<Set>> GetAllSetsByUserIdAsync(string userId);
        public Task<Set?> GetSetByIdAsync(int setId);
        public Task CreateSetAsync(Set set);
        public Task UpdateSetAsync(Set set);
        public Task DeleteSetAsync(int setId);
    }
}

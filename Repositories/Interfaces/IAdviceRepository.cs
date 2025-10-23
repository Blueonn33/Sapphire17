
using Sapphire17.Models;

namespace Sapphire17.Repositories.Interfaces
{
    public interface IAdviceRepository
    {
        public Task<IEnumerable<Advice>> GetAllAdvicesByUserIdAsync(string userId);
        public Task<Advice?> GetAdviceByIdAsync(int id);
        public Task CreateAdviceAsync(Advice advice);
        public Task UpdateAdviceAsync(Advice advice);
        public Task DeleteAdviceAsync(int id);
    }
}

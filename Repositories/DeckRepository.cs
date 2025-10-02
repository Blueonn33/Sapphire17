using Sapphire17.Data;
using Sapphire17.Repositories.Interfaces;

namespace Sapphire17.Repositories
{
    public class DeckRepository : IDeckRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ISetRepository _setRepository;

        public DeckRepository(ApplicationDbContext context, ISetRepository setRepository)
        {
            _context = context;
            _setRepository = setRepository;
        }
    }
}

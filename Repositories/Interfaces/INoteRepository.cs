using Sapphire17.Models;

namespace Sapphire17.Repositories.Interfaces
{
    public interface INoteRepository
    {
        public Task<IEnumerable<Note>> GetAllNotesByUserIdAsync(string userId);
        public Task<Note?> GetNoteByIdAsync(int id);
        public Task CreateNoteAsync(Note note);
        public Task UpdateNoteAsync(Note note);
        public Task DeleteNoteAsync(int id);
    }
}

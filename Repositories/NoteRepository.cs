using Microsoft.EntityFrameworkCore;
using Sapphire17.Areas.Identity.Data;
using Sapphire17.Data;
using Sapphire17.Models;
using Sapphire17.Repositories.Interfaces;

namespace Sapphire17.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext _context;

        public NoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Note>> GetAllNotesByUserIdAsync(string userId)
        {
            if(userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var notes = await _context.Notes.Where(n => n.UserId == userId).ToListAsync();
            return notes;
        }

        public async Task<Note?> GetNoteByIdAsync(int id)
        {
            if(id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var note = await _context.Notes.FindAsync(id);
            return note;
        }

        public async Task CreateNoteAsync(Note note)
        {
            if(note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }

            await _context.Notes.AddAsync(note);
            _context.SaveChanges();
        }

        public async Task UpdateNoteAsync(Note note)
        {
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }

            _context.Notes.Update(note);
            _context.SaveChanges();
        }

        public async Task DeleteNoteAsync(int id)
        {
            if(id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var note = await _context.Notes.FindAsync(id);
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }
    }
}

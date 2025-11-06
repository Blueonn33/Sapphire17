using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using Sapphire17.Areas.Identity.Data;
using Sapphire17.Models;
using Sapphire17.Repositories.Interfaces;
using Sapphire17.ViewModels;
using System.CodeDom;

namespace Sapphire17.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteRepository _noteRepository;
        private readonly UserManager<User> _userManager;

        public NoteController(INoteRepository noteRepository, UserManager<User> userManager)
        {
            _noteRepository = noteRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                throw new Exception("User not found");
            }

            var notes = await _noteRepository.GetAllNotesByUserIdAsync(userId);
            return View(notes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNote(NoteViewModel noteViewModel)
        {
            string userId = _userManager.GetUserId(User);
            User user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (noteViewModel.ImageFile != null && noteViewModel.ImageFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await noteViewModel.ImageFile.CopyToAsync(ms);
                    noteViewModel.ImageData = ms.ToArray();
                    noteViewModel.ImageMimeType = noteViewModel.ImageFile.ContentType;
                }
            }

            var note = new Note
            {
                Title = noteViewModel.Title,
                Description = noteViewModel.Description,
                ImageData = noteViewModel.ImageData,
                ImageMimeType = noteViewModel.ImageMimeType,
                Important = noteViewModel.Important,
                Theme = noteViewModel.Theme,
                Completed = noteViewModel.Completed,
                UserId = user.Id,
                User = user
            };

            await _noteRepository.CreateNoteAsync(note);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetNoteImage(int noteId)
        {
            var note = await _noteRepository.GetNoteByIdAsync(noteId);

            if (note == null || note.ImageData == null || note.ImageMimeType == null)
            {
                return NotFound();
            }

            return File(note.ImageData, note.ImageMimeType);
        }
    }
}

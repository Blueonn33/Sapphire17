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
        public async Task<IActionResult> Edit(int noteId)
        {
            if (noteId == 0)
            {
                return NotFound();
            }

            var note = await _noteRepository.GetNoteByIdAsync(noteId);

            if (note == null)
            {
                return NotFound();
            }

            var noteVm = new NoteViewModel
            {
                Title = note.Title,
                Description = note.Description,
                Important = note.Important,
                Theme = note.Theme,
                ImageData = note.ImageData,
                ImageMimeType = note.ImageMimeType,
                Completed = note.Completed
            };

            ViewBag.noteId = note.Id;

            return View(noteVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NoteViewModel noteViewModel, int noteId)
        {
            string userId = _userManager.GetUserId(User);
            User user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (ModelState.IsValid)
            {
                var note = await _noteRepository.GetNoteByIdAsync(noteId);

                if (note == null)
                {
                    return NotFound();
                }

                note.Title = noteViewModel.Title;
                note.Description = noteViewModel.Description;
                note.Important = noteViewModel.Important;
                note.Theme = noteViewModel.Theme;
                note.Completed = noteViewModel.Completed;

                if (noteViewModel.ImageFile != null && noteViewModel.ImageFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await noteViewModel.ImageFile.CopyToAsync(ms);
                        note.ImageData = ms.ToArray();
                        note.ImageMimeType = noteViewModel.ImageFile.ContentType;
                    }
                }
                else
                {
                    note.ImageData = note.ImageData ?? noteViewModel.ImageData;
                    note.ImageMimeType = note.ImageMimeType ?? noteViewModel.ImageMimeType;
                }

                await _noteRepository.UpdateNoteAsync(note);
                return RedirectToAction("Index");
            }

            ViewBag.noteId = noteId;
            return View(noteViewModel);
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

        [HttpDelete]
        public async Task<IActionResult> DeleteNote(int noteId)
        {
            var note = await _noteRepository.GetNoteByIdAsync(noteId);

            if (note == null)
            {
                return NotFound();
            }

            _noteRepository.DeleteNoteAsync(noteId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CompleteNote(int noteId)
        {
            if (noteId == 0)
            {
                return NotFound();
            }

            var note = await _noteRepository.GetNoteByIdAsync(noteId);

            if (note == null)
            {
                return NotFound();
            }

            note.Completed = true;
            await _noteRepository.UpdateNoteAsync(note);
            return RedirectToAction("Index");
        }
    }
}

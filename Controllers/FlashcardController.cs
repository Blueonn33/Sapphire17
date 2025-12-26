using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sapphire17.Areas.Identity.Data;
using Sapphire17.Models;
using Sapphire17.Repositories;
using Sapphire17.Repositories.Interfaces;
using Sapphire17.ViewModels;

namespace Sapphire17.Controllers
{
    public class FlashcardController : Controller
    {
        private readonly IFlashcardRepository _flashcardRepository;
        private readonly IResultRepository _resultRepository;
        private readonly IDeckRepository _deckRepository;
        private readonly UserManager<User> _userManager;

        public FlashcardController(IFlashcardRepository flashcardRepository, IDeckRepository deckRepository, IResultRepository resultRepository,
            UserManager<User> userManager)
        {
            _flashcardRepository = flashcardRepository;
            _deckRepository = deckRepository;
            _resultRepository = resultRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int deckId)
        {
            if (deckId == 0)
            {
                return BadRequest("Missing deckId");
            }

            var flashcards = await _flashcardRepository.GetAllFlashcardsByDeckIdAsync(deckId);
            ViewBag.deckId = deckId;

            return View(flashcards);
        }

        [HttpGet]
        public async Task<IActionResult> OpenFlashcards(int deckId)
        {
            if (deckId == 0)
            {
                return BadRequest("Missing deckId");
            }

            var flashcards = await _flashcardRepository.GetAllFlashcardsByDeckIdAsync(deckId);
            ViewBag.deckId = deckId;
            return View(flashcards);
        }

        [HttpGet]
        public async Task<IActionResult> Flashcard(int flashcardId)
        {
            if (flashcardId == 0)
                return BadRequest("Missing flashcardId");

            var flashcard = await _flashcardRepository.GetFlashcardByIdAsync(flashcardId);
            if (flashcard == null)
                return NotFound();

            var results = await _resultRepository.GetAllResultsByFlashcardIdAsync(flashcardId);

            var deck = await _deckRepository.GetDeckByIdAsync(flashcard.DeckId);
            ViewBag.deckName = deck?.Name;
            ViewBag.setName = deck?.Set?.Name;

            var model = new FlashcardDetailsViewModel
            {
                Flashcard = flashcard,
                Results = results
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int deckId)
        {
            if (deckId == 0)
            {
                return BadRequest("Missing deckId");
            }

            var deck = await _deckRepository.GetDeckByIdAsync(deckId);

            if (deck == null)
            {
                return NotFound();
            }

            ViewBag.deckId = deckId;

            var model = new FlashcardViewModel
            {
                DeckId = deckId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFlashcard(FlashcardViewModel flashcardViewModel)
        {
            if (flashcardViewModel.DeckId == 0)
            {
                throw new Exception("Deck not found");
            }

            var deck = await _deckRepository.GetDeckByIdAsync(flashcardViewModel.DeckId);

            var flashcard = new Flashcard
            {
                Question = flashcardViewModel.Question,
                Answer = flashcardViewModel.Answer,
                DeckId = flashcardViewModel.DeckId,
                Deck = deck
            };

            await _flashcardRepository.CreateFlashcardAsync(flashcard);
            ViewBag.deckId = flashcardViewModel.DeckId;
            return RedirectToAction("Index", "Flashcard", new { deckId = flashcardViewModel.DeckId });
        }
    }
}

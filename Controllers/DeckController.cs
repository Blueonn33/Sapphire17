using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sapphire17.Areas.Identity.Data;
using Sapphire17.Models;
using Sapphire17.Repositories.Interfaces;
using Sapphire17.ViewModels;

namespace Sapphire17.Controllers
{
    public class DeckController : Controller
    {
        private readonly IDeckRepository _deckRepository;
        private readonly ISetRepository _setRepository;
        private readonly UserManager<User> _userManager;

        public DeckController(IDeckRepository deckRepository, ISetRepository setRepository, UserManager<User> userManager)
        {
            _deckRepository = deckRepository;
            _setRepository = setRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int setId)
        {
            if (setId == 0)
            {
                return BadRequest("Missing setId");
            }

            var decks = await _deckRepository.GetAllDecksBySetIdAsync(setId); 
            ViewBag.setId = setId;
            return View(decks);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int setId)
        {
            if (setId == 0)
            {
                return BadRequest("Missing setId");
            }

            var set = await _setRepository.GetSetByIdAsync(setId);

            if (set == null)
            {
                return NotFound();
            }

            ViewBag.setId = setId;

            var model = new DeckViewModel
            {
                SetId = setId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeck(DeckViewModel deckViewModel)
        {
            if (deckViewModel.SetId == 0)
            {
                throw new Exception("Set not found");
            }

            var set = await _setRepository.GetSetByIdAsync(deckViewModel.SetId);

            if (deckViewModel.ImageFile != null && deckViewModel.ImageFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await deckViewModel.ImageFile.CopyToAsync(ms);
                    deckViewModel.ImageData = ms.ToArray();
                    deckViewModel.ImageMimeType = deckViewModel.ImageFile.ContentType;
                }
            }

            var deck = new Deck
            {
                Name = deckViewModel.Name,
                Description = deckViewModel.Description,
                ImageData = deckViewModel.ImageData,
                ImageMimeType = deckViewModel.ImageMimeType,
                Visible = deckViewModel.Visible,
                SetId = deckViewModel.SetId,
                Set = set
            };

            await _deckRepository.CreateDeckAsync(deck);
            ViewBag.setId = deckViewModel.SetId;
            return RedirectToAction("Index", "Set");
        }

        [HttpGet]
        public async Task<IActionResult> GetDeckImage(int deckId)
        {
            var deck = await _deckRepository.GetDeckByIdAsync(deckId);

            if (deck == null || deck.ImageData == null || deck.ImageMimeType == null)
            {
                return NotFound();
            }

            return File(deck.ImageData, deck.ImageMimeType);
        }

    }
}

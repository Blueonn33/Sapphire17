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
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeck(DeckViewModel deckViewModel, int setId)
        {
            if (setId == 0)
            {
                throw new Exception("Set not found");
            }

            var set = await _setRepository.GetSetByIdAsync(setId);

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
                SetId = setId,
                Set = set
            };

            await _deckRepository.CreateDeckAsync(deck);
            return RedirectToAction("Index", "Set");
        }
    }
}

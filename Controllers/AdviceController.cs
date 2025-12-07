using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sapphire17.Areas.Identity.Data;
using Sapphire17.Models;
using Sapphire17.Repositories.Interfaces;
using Sapphire17.ViewModels;

namespace Sapphire17.Controllers
{
    public class AdviceController : Controller
    {
        private readonly IAdviceRepository _adviceRepository;
        private readonly UserManager<User> _userManager;

        public AdviceController(IAdviceRepository adviceRepository, UserManager<User> userManager)
        {
            _adviceRepository = adviceRepository;
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
        public async Task<IActionResult> CreateAdvice(AdviceViewModel adviceViewModel)
        {
            string userId = _userManager.GetUserId(User);
            User user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }


            if (adviceViewModel.ImageFile != null && adviceViewModel.ImageFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await adviceViewModel.ImageFile.CopyToAsync(ms);
                    adviceViewModel.ImageData = ms.ToArray();
                    adviceViewModel.ImageMimeType = adviceViewModel.ImageFile.ContentType;
                }
            }

            var advice = new Advice
            {
                Name = adviceViewModel.Name,
                Value = adviceViewModel.Value,
                UserId = user.Id,
                User = user,
                ImageData = adviceViewModel.ImageData,
                ImageMimeType = adviceViewModel.ImageMimeType,
                Type = adviceViewModel.Type
            };

            await _adviceRepository.CreateAdviceAsync(advice);
            return RedirectToAction("Index");
        }
    }
}

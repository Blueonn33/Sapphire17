using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Sapphire17.Areas.Identity.Data;
using Sapphire17.Models;
using Sapphire17.Repositories.Interfaces;
using Sapphire17.ViewModels;

namespace Sapphire17.Controllers
{
    public class SetController : Controller
    {
        private readonly ISetRepository _repository;
        private readonly UserManager<User> _userManager;

        public SetController(ISetRepository repository, UserManager<User> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userId = _userManager.GetUserId(User);
            var sets = await _repository.GetAllSetsByUserIdAsync(userId);
            return View(sets);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSet(SetViewModel setViewModel)
        {
            string userId = _userManager.GetUserId(User);
            User user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (setViewModel.ImageFile != null && setViewModel.ImageFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await setViewModel.ImageFile.CopyToAsync(ms);
                    setViewModel.ImageData = ms.ToArray();
                    setViewModel.ImageMimeType = setViewModel.ImageFile.ContentType;
                }
            }

            var set = new Set
            {
                Name = setViewModel.Name,
                ImageData = setViewModel.ImageData,
                ImageMimeType = setViewModel.ImageMimeType,
                Visible = setViewModel.Visible,
                Favorite = setViewModel.Favorite,
                UserId = userId,
                User = user
            };

            await _repository.CreateSetAsync(set);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int setId)
        {
            if (setId == 0)
            {
                return NotFound();
            }

            var set = await _repository.GetSetByIdAsync(setId);

            if (set == null)
            {
                return NotFound();
            }

            var setViewModel = new SetViewModel
            {
                Name = set.Name,
                ImageData = set.ImageData,
                ImageMimeType = set.ImageMimeType,
                Visible = set.Visible,
                Favorite = set.Favorite
            };

            ViewBag.setId = set.Id;
            return View(setViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditSet(SetViewModel setViewModel, int setId)
        {
            string userId = _userManager.GetUserId(User);
            User user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (ModelState.IsValid)
            {
                var set = await _repository.GetSetByIdAsync(setId);

                if (set == null)
                {
                    return NotFound();
                }

                if (setViewModel.ImageFile != null && setViewModel.ImageFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await setViewModel.ImageFile.CopyToAsync(ms);
                        setViewModel.ImageData = ms.ToArray();
                        setViewModel.ImageMimeType = setViewModel.ImageFile.ContentType;
                    }
                }
                else
                {
                    setViewModel.ImageData = set.ImageData;
                    setViewModel.ImageMimeType = set.ImageMimeType;
                }

                set.Name = setViewModel.Name;
                set.ImageData = setViewModel.ImageData;
                set.ImageMimeType = setViewModel.ImageMimeType;
                set.Visible = setViewModel.Visible;
                set.Favorite = setViewModel.Favorite;
                set.User = user;
                set.UserId = userId;

                await _repository.UpdateSetAsync(set);
                return RedirectToAction("Index");
            }

            return View(setViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetSetImage(int setId)
        {
            var set = await _repository.GetSetByIdAsync(setId);

            if (set == null || set.ImageData == null || set.ImageMimeType == null)
            {
                return NotFound();
            }

            return File(set.ImageData, set.ImageMimeType);
        }
    }
}

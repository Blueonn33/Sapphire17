using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sapphire17.Areas.Identity.Data;
using Sapphire17.Models;
using Sapphire17.Repositories.Interfaces;
using Sapphire17.ViewModels;

namespace Sapphire17.Controllers
{
    public class VideoController : Controller
    {
        private readonly IVideoRepository _videoRepository;
        private readonly UserManager<User> _userManager;

        public VideoController(IVideoRepository videoRepository, UserManager<User> userManager)
        {
            _videoRepository = videoRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                throw new Exception("User is not found");
            }

            var videos = await _videoRepository.GetAllVideosByUserIdAsync(userId);
            return View(videos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVideo(VideoViewModel videoViewModel)
        {
            string userId = _userManager.GetUserId(User);
            User user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("User is not found");
            }

            Video video = new Video
            {
                Url = videoViewModel.Url,
                Title = videoViewModel.Title,
                User = user,
                UserId = userId
            };

            await _videoRepository.CreateVideoAsync(video);
            return RedirectToAction("Index");
        }
    }
}

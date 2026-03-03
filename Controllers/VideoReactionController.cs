using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sapphire17.Areas.Identity.Data;
using Sapphire17.Models;
using Sapphire17.Repositories.Interfaces;
using Sapphire17.ViewModels;

namespace Sapphire17.Controllers
{
    public class VideoReactionController : Controller
    {
        private readonly IVideoReactionRepository _reactionRepository;
        private readonly IVideoRepository _videoRepository;
        private readonly UserManager<User> _userManager;

        public VideoReactionController(IVideoReactionRepository reactionRepository, IVideoRepository videoRepository, UserManager<User> userManager)
        {
            _reactionRepository = reactionRepository;
            _videoRepository = videoRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int videoId)
        {
            if (videoId == 0)
            {
                throw new Exception("Video not found");
            }

            var reactions = await _reactionRepository.GetAllReactionsByVideoIdAsync(videoId);

            if (reactions == null)
            {
                throw new Exception("This video does not have reactions");
            }

            return View(reactions);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int videoId)
        {
            if (videoId == 0)
            {
                throw new Exception("Video not found");
            }

            var video = _videoRepository.GetVideoByIdAsync(videoId);
            return View(video);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReaction(VideoReactionViewModel reactionViewModel)
        {
            if (reactionViewModel == null)
            {
                throw new Exception("Reaction not found");
            }

            User user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            string userId = await _userManager.GetUserIdAsync(user);

            var videoReaction = new VideoReaction
            {
                Reaction = reactionViewModel.Reaction,
                User = user,
                UserId = userId,
            }
        }
    }
}

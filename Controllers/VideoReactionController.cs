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

        [HttpPost]
        public async Task<IActionResult> Create(int videoId, VideoReactionViewModel reactionViewModel)
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
            var video = await _videoRepository.GetVideoByIdAsync(videoId);

            var videoReaction = new VideoReaction
            {
                Reaction = reactionViewModel.Reaction,
                Video = video,
                VideoId = videoId,
                User = user,
                UserId = userId
            };

            await _reactionRepository.CreateReactionAsync(videoReaction);

            return RedirectToAction("Index", "Video");
        }
    }
}

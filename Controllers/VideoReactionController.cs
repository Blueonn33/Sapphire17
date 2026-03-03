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
        public async Task<IActionResult> Create([FromBody] VideoReactionViewModel request)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var existing = await _reactionRepository.GetUserReactionAsync(user.Id, request.VideoId);
            if (existing != null)
            {
                return Json(new
                {
                    success = false,
                    message = "already-reacted"
                });
            }

            var reaction = new VideoReaction
            {
                VideoId = request.VideoId,
                Reaction = request.Reaction,
                UserId = user.Id
            };

            await _reactionRepository.CreateReactionAsync(reaction);

            return Json(new
            {
                success = true,
                likes = await _reactionRepository.CountReactions(request.VideoId, "Like"),
                dislikes = await _reactionRepository.CountReactions(request.VideoId, "Dislike")
            });
        }
    }
}

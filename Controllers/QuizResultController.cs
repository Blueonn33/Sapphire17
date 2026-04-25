using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sapphire17.Areas.Identity.Data;
using Sapphire17.Repositories.Interfaces;

namespace Sapphire17.Controllers
{
    public class QuizResultController : Controller
    {
        private readonly IQuizResultRepository _quizResultRepository;
        private readonly UserManager<User> _userManager;

        public QuizResultController(IQuizResultRepository quizResultRepository, UserManager<User> userManager)
        {
            _quizResultRepository = quizResultRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int quizCollectionId)
        {
            var user = await _userManager.GetUserAsync(User);
            string userId = user.Id;

            var quizResults =
                await _quizResultRepository.GetQuizResultByQuizCollectionAndUser(quizCollectionId, userId);
            var latestResult = quizResults.OrderByDescending(qr => qr.DateCompleted).FirstOrDefault();

            return View(latestResult);
        }

    }
}

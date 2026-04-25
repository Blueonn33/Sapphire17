using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sapphire17.Areas.Identity.Data;
using Sapphire17.Models;
using Sapphire17.Repositories.Interfaces;
using Sapphire17.ViewModels;

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

        [HttpPost]
        public async Task<IActionResult> Create(int quizCollectionId, QuizResultViewModel quizResultViewModel)
        {
            var user = await _userManager.GetUserAsync(User);
            string userId = user.Id;

            QuizResult quizResult = new QuizResult
            {
                Score = quizResultViewModel.Score,
                TotalScore = quizResultViewModel.TotalScore,
                QuizCollectionId = quizCollectionId,
                UserId = userId
            };

            await _quizResultRepository.CreateQuizResult(quizResult);
            ViewBag.QuizCollectionId = quizCollectionId;

            return RedirectToAction("Index", new
            {
                quizCollectionId = quizCollectionId
            });
        }
    }
}

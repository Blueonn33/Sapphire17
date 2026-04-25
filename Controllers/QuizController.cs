using Microsoft.AspNetCore.Mvc;
using Sapphire17.Models;
using Sapphire17.Repositories.Interfaces;
using Sapphire17.ViewModels;

namespace Sapphire17.Controllers
{
    public class QuizController : Controller
    {
        private readonly IQuizRepository _quizRepository;

        public QuizController(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int quizCollectionId)
        {
            ViewBag.QuizCollectionId = quizCollectionId;

            var quizzes = await _quizRepository.GetAllQuizzesAsync(quizCollectionId);
            return View(quizzes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuiz(int quizCollectionId, QuizViewModel quizViewModel)
        {
            if (quizCollectionId == 0)
            {
                return RedirectToAction("Index", "QuizCollection");
            }

            Quiz quiz = new Quiz
            {
                Question = quizViewModel.Question,
                AnswerA = quizViewModel.AnswerA,
                AnswerB = quizViewModel.AnswerB,
                AnswerC = quizViewModel.AnswerC,
                AnswerD = quizViewModel.AnswerD,
                CorrectAnswer = quizViewModel.CorrectAnswer,
                Points = quizViewModel.Points,
                QuizCollectionId = quizCollectionId
            };

            await _quizRepository.CreateQuiz(quiz);
            ViewBag.QuizCollectionId = quizCollectionId;
            return RedirectToAction("Index", "Quiz", new
            {
                QuizCollectionId = quizCollectionId
            });
        }

        [HttpGet]
        public async Task<IActionResult> StartTest()
        {

        }
    }
}

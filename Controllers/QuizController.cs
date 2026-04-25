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
        public async Task<IActionResult> Index()
        {
            var quizzes = await _quizRepository.GetAllQuizzesAsync();
            return View(quizzes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuiz(QuizViewModel quizViewModel)
        {
            Quiz quiz = new Quiz
            {
                Question = quizViewModel.Question,
                AnswerA = quizViewModel.AnswerA,
                AnswerB = quizViewModel.AnswerB,
                AnswerC = quizViewModel.AnswerC,
                AnswerD = quizViewModel.AnswerD,
                CorrectAnswer = quizViewModel.CorrectAnswer,
                Points = quizViewModel.Points,
                QuizCollectionId = quizViewModel.QuizCollectionId
            };

            await _quizRepository.CreateQuiz(quiz);
            return RedirectToAction("Index");
        }
    }
}

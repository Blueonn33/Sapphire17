using Microsoft.AspNetCore.Mvc;
using Sapphire17.Repositories.Interfaces;

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
        public async Task<IActionResult> CreateQuiz()
        {

        }
    }
}

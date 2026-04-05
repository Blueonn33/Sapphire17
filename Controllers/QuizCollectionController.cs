using Microsoft.AspNetCore.Mvc;
using Sapphire17.Models;
using Sapphire17.Repositories.Interfaces;
using Sapphire17.ViewModels;

namespace Sapphire17.Controllers
{
    public class QuizCollectionController : Controller
    {
        private readonly IQuizCollectionRepository _quizCollectionRepository;

        public QuizCollectionController(IQuizCollectionRepository quizCollectionRepository)
        {
            _quizCollectionRepository = quizCollectionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var quizCollections = await _quizCollectionRepository.GetAllQuizCollections();
            return View(quizCollections);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuizCollection(QuizCollectionViewModel quizCollectionViewModel)
        {
            if (quizCollectionViewModel.ImageFile != null && quizCollectionViewModel.ImageFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await quizCollectionViewModel.ImageFile.CopyToAsync(ms);
                    quizCollectionViewModel.ImageData = ms.ToArray();
                    quizCollectionViewModel.ImageMimeType = quizCollectionViewModel.ImageFile.ContentType;
                }
            }

            QuizCollection quizCollection = new QuizCollection
            {
                Name = quizCollectionViewModel.Name,
                Description = quizCollectionViewModel.Description,
                ImageData = quizCollectionViewModel.ImageData,
                ImageMimeType = quizCollectionViewModel.ImageMimeType
            };

            await _quizCollectionRepository.CreateQuizCollection(quizCollection);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetQuizCollectionImage(int quizCollectionId)
        {
            var quizCollection = await _quizCollectionRepository.GetQuizCollectionById(quizCollectionId);

            if (quizCollection == null || quizCollection.ImageData == null || quizCollection.ImageMimeType == null)
            {
                return NotFound();
            }

            return File(quizCollection.ImageData, quizCollection.ImageMimeType);
        }
    }
}

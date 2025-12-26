using Microsoft.AspNetCore.Mvc;
using Sapphire17.Repositories;
using Sapphire17.Repositories.Interfaces;
using Sapphire17.ViewModels;

namespace Sapphire17.Controllers
{
    public class ResultController : Controller
    {
        private readonly IResultRepository _resultRepository;
        private readonly IFlashcardRepository _flashcardRepository;
        
        public ResultController(IResultRepository resultRepository, IFlashcardRepository flashcardRepository)
        {
            _resultRepository = resultRepository;
            _flashcardRepository = flashcardRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ResultViewModel model)
        {
            if (model.FlashcardId == 0)
                return BadRequest("Invalid flashcard id");

            var flashcard =
                await _flashcardRepository.GetFlashcardByIdAsync(model.FlashcardId);

            if (flashcard == null)
                return BadRequest("Flashcard not found");

            var result = new Models.Result
            {
                FlashcardId = flashcard.Id,
                Points = model.Points,
                DateAnswered = DateTime.Now
            };

            await _resultRepository.CreateResultAsync(result);

            return Json(new
            {
                points = result.Points,
                dateAnswered = result.DateAnswered.ToString("dd.MM.yyyy HH:mm")
            });
        }
    }
}

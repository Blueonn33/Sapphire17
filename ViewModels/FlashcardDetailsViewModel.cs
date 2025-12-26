using Sapphire17.Models;

namespace Sapphire17.ViewModels
{
    public class FlashcardDetailsViewModel
    {
        public Flashcard Flashcard { get; set; }
        public IEnumerable<Result> Results { get; set; }
    }
}

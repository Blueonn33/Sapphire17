namespace Sapphire17.ViewModels
{
    public class ResultViewModel
    {
        public int Points { get; set; }
        public DateTime DateAnswered { get; set; } = DateTime.Now;
        public int FlashcardId { get; set; }
    }
}

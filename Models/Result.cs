using System.ComponentModel.DataAnnotations.Schema;
using Sapphire17.Areas.Identity.Data;

namespace Sapphire17.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int Points { get; set; }
        public DateTime DateAnswered { get; set; } = DateTime.Now;

        [ForeignKey(nameof(FlashcardId))]
        public int FlashcardId { get; set; }
        public Flashcard Flashcard { get; set; }
    }
}

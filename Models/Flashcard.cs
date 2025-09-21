using System.ComponentModel.DataAnnotations.Schema;

namespace Sapphire17.Models
{
    public class Flashcard
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        [ForeignKey(nameof(DeckId))]
        public int DeckId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Sapphire17.Models
{
    public class Deck
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageMimeType { get; set; }
        public bool Visible { get; set; }

        [ForeignKey(nameof(CollectionId))]
        public int CollectionId { get; set; }

        public ICollection<Flashcard> Flashcards { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using Sapphire17.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sapphire17.Models
{
    public class Set
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageMimeType { get; set; }
        public bool Visible { get; set; }
        public bool Favorite { get; set; }

        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<Deck> Decks { get; set; }
    }
}

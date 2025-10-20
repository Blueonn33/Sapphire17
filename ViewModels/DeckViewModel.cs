using Sapphire17.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sapphire17.ViewModels
{
    public class DeckViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile? ImageFile { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageMimeType { get; set; }
        public bool Visible { get; set; }
    }
}

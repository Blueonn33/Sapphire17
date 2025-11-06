using Sapphire17.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sapphire17.ViewModels
{
    public class NoteViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? ImageFile { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageMimeType { get; set; }
        public bool Important { get; set; }
        public string Theme { get; set; }
        public bool Completed { get; set; }
    }
}

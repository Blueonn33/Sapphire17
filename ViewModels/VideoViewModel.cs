using Sapphire17.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sapphire17.ViewModels
{
    public class VideoViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageMimeType { get; set; }
    }
}

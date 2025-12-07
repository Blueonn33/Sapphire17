using Sapphire17.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sapphire17.ViewModels
{
    public class AdviceViewModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageMimeType { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Type { get; set; }
    }
}

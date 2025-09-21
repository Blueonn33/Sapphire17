using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sapphire17.Models
{
    public class Advice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageMimeType { get; set; }
        public string Type { get; set; }

        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using Sapphire17.Models;

namespace Sapphire17.Areas.Identity.Data
{
    public class User : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
        [PersonalData]
        public string? Description { get; set; }
        [PersonalData]
        public byte[]? ImageData { get; set; }
        [PersonalData]
        public string? ImageMimeType { get; set; }

        public ICollection<Set> Sets { get; set; }
        public ICollection<Advice> Advices { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using Sapphire17.Models;

namespace Sapphire17.Areas.Identity.Data
{
    public class User : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
        public ICollection<Set> Sets { get; set; }
        public ICollection<Advice> Advices { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<Video> Videos { get; set; }
    }
}

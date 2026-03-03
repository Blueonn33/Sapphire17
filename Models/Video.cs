using Sapphire17.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sapphire17.Models
{
    public class Video
    {
        public int Id
        {
            get; set;
        }
        public string Url
        {
            get; set;
        }
        public string Title
        {
            get; set;
        }

        [ForeignKey(nameof(UserId))]
        public string UserId
        {
            get; set;
        }
        public User User
        {
            get; set;
        }
    }
}

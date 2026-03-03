using Sapphire17.Areas.Identity.Data;

namespace Sapphire17.Models
{
    public class VideoReaction
    {
        public int Id
        {
            get; set;
        }
        public string Reaction
        {
            get; set;
        }

        public Video Video
        {
            get; set;
        }
        public int VideoId
        {
            get; set;
        }

        public User User
        {
            get; set;
        }
        public string UserId
        {
            get; set;
        }
    }
}

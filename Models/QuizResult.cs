using Sapphire17.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sapphire17.Models
{
    public class QuizResult
    {
        public int Id
        {
            get; set;
        }
        public int Score
        {
            get; set;
        }

        public DateTime DateCompleted { get; set; } = DateTime.Now;

        [ForeignKey(nameof(UserId))]
        public string UserId
        {
            get; set;
        }

        public User User
        {
            get; set;
        }

        [ForeignKey(nameof(QuizCollectionId))]
        public int QuizCollectionId
        {
            get; set;
        }
        public QuizCollection QuizCollection
        {
            get; set;
        }
    }
}

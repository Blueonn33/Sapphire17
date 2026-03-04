using System.ComponentModel.DataAnnotations.Schema;

namespace Sapphire17.Models
{
    public class QuizResultTotal
    {
        public int Id
        {
            get; set;
        }
        public int TotalPoints
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

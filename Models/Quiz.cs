using System.ComponentModel.DataAnnotations.Schema;

namespace Sapphire17.Models
{
    public class Quiz
    {
        public int Id
        {
            get; set;
        }
        public string Question
        {
            get; set;
        }
        public string Answer
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

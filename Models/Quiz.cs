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
        public string AnswerA
        {
            get; set;
        }
        public string AnswerB
        {
            get; set;
        }
        public string AnswerC
        {
            get; set;
        }
        public string AnswerD
        {
            get; set;
        }

        public string CorrectAnswer
        {
            get; set;
        }

        public int Points
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

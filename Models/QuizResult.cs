using System.ComponentModel.DataAnnotations.Schema;

namespace Sapphire17.Models
{
    public class QuizResult
    {
        public int Id
        {
            get; set;
        }
        public int Points
        {
            get; set;
        }

        [ForeignKey(nameof(QuizId))]
        public int QuizId
        {
            get; set;
        }
        public Quiz Quiz
        {
            get; set;
        }
    }
}

namespace Sapphire17.ViewModels
{
    public class QuizViewModel
    {
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
        } = 0;

        public int QuizCollectionId
        {
            get; set;
        }
    }
}

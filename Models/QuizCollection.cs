namespace Sapphire17.Models
{
    public class QuizCollection
    {
        public int Id
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
        public byte[]? ImageData
        {
            get; set;
        }
        public string? ImageMimeType
        {
            get; set;
        }
        public ICollection<Quiz> Quizzes
        {
            get; set;
        }
        public ICollection<QuizResult> QuizResults
        {
            get; set;
        }
    }
}

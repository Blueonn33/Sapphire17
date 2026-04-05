
namespace Sapphire17.ViewModels
{
    public class QuizCollectionViewModel
    {
        public string Name
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
        public IFormFile? ImageFile
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
    }
}

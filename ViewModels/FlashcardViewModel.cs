using Sapphire17.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sapphire17.ViewModels
{
    public class FlashcardViewModel
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public int DeckId { get; set; }
    }
}

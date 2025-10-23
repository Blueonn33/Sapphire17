using Microsoft.AspNetCore.Mvc;

namespace Sapphire17.Controllers
{
    public class FlashcardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Sapphire17.Controllers
{
    public class NoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

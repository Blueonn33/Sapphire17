using Microsoft.AspNetCore.Mvc;

namespace Sapphire17.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sapphire17.Areas.Identity.Data;
using Sapphire17.Models;
using Sapphire17.Repositories.Interfaces;

namespace Sapphire17.Controllers
{
    public class SetController : Controller
    {
        private readonly ISetRepository _repository;

        public SetController(ISetRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateSet(Set set)
        //{

        //}
    }
}

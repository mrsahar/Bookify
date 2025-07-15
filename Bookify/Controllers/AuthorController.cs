using Bookify.Repos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IGenresService service;

        public AuthorController(IGenresService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            var result = service.GetAll();
            return View(result);
        }

    }
}

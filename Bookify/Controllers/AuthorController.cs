using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

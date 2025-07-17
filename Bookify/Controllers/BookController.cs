using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

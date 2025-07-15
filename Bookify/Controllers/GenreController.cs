using Bookify.Models.Entity;
using Bookify.Repos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenresService service;

        public GenreController(IGenresService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            var result = service.GetAll();
            return View(result);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return View(genre);
            }
            var result = service.Add(genre);
            if (result == true)
            {
                TempData["msg"] = "Genre Added Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var record = service.GetById(id);
            if (record == null)
            {
                TempData["msg"] = "No Data found";
                return View();
            }
            return View(record);
        }
        [HttpPost]
        public IActionResult Update(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return View(genre);
            }

            var result = service.Update(genre);

            if (result == true)
            {
                TempData["msg"] = "Genre Updated Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            if (result == true)
            {
                TempData["msg"] = "Deleted Successfully";
            }
            else
            {
                TempData["msg"] = "Deleted SomeThing Went wrong";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

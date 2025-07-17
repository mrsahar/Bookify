using Bookify.Models.Entity;
using Bookify.Repos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthor service;

        public AuthorController(IAuthor service)
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
        public IActionResult Add(Author author)
        {
            if (ModelState.IsValid)
            {
                var result = service.Add(author);
                if (result == true)
                {
                    TempData["msg"] = "Author Added Successfully";
                    return RedirectToAction(nameof(Index));

                }
            }
            return View(author);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var record = service.GetById(id);
            return View(record);
        }
        [HttpPost]
        public IActionResult Update(Author author)
        {
            var result = service.Update(author);
            if (result == true)
            {
                TempData["msg"] = "Author Updated Successfully";
                return RedirectToAction(nameof(Index));

            }
            return View(author);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            if (result == true)
            {
                TempData["msg"] = "Deleted Successfully";
                return RedirectToAction(nameof(Index));

            }
            else
            {
                TempData["msg"] = "UnSuccessfully";
            }
            return RedirectToAction(nameof(Index));
        }

    }
}

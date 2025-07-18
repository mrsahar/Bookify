using Bookify.Models.Entity;
using Bookify.Repos.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookify.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly IAuthor authorService;
        private readonly IPublisher publisherService;
        private readonly IGenresService genresService;

        public BookController(IBookService bookService, IAuthor authorService, IPublisher publisherService, IGenresService genresService)
        {
            this.bookService = bookService;
            this.authorService = authorService;
            this.publisherService = publisherService;
            this.genresService = genresService;
        }
        public IActionResult Index()
        {
            var result = bookService.GetBooks();
            return View(result);
        }

        public IActionResult Add()
        {
            var model = new Book();
            model.AutherList = authorService.GetAll()
                .Select(a => new SelectListItem { Text = a.AuthorName, Value = a.AuthorId.ToString() }).ToList();
            model.PublisherList = publisherService.GetPublishers()
                .Select(p => new SelectListItem { Text = p.PublisherName, Value = p.PublisherId.ToString() }).ToList();
            model.GenreList = genresService.GetAll()
                .Select(g => new SelectListItem { Text = g.Name, Value = g.GenreID.ToString() }).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(Book Book)
        {
            var model = new Book();
            model.AutherList = authorService.GetAll()
                .Select(a => new SelectListItem
                {
                    Text = a.AuthorName,
                    Value = a.AuthorId.ToString(),
                    Selected = a.AuthorId == model.AuthorId
                }).ToList();
            model.PublisherList = publisherService.GetPublishers()
                .Select(p => new SelectListItem
                {
                    Text = p.PublisherName,
                    Value = p.PublisherId.ToString(),
                    Selected = p.PublisherId == model.PublisherID
                }).ToList();
            model.GenreList = genresService.GetAll()
                .Select(g => new SelectListItem { Text = g.Name, Value = g.GenreID.ToString(), Selected = g.GenreID == model.GenreID }).ToList();

            var result = bookService.Add(Book);
            if (result == true)
            {
                TempData["msg"] = "Book Updated Successfully";
                return RedirectToAction(nameof(Index));

            }
            return View(model);

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = bookService.findById(id);
            model.AutherList = authorService.GetAll()
                .Select(a => new SelectListItem
                {
                    Text = a.AuthorName,
                    Value = a.AuthorId.ToString(),
                    Selected = a.AuthorId == model.AuthorId
                }).ToList();
            model.PublisherList = publisherService.GetPublishers()
                .Select(p => new SelectListItem
                {
                    Text = p.PublisherName,
                    Value = p.PublisherId.ToString(),
                    Selected = p.PublisherId == model.PublisherID
                }).ToList();
            model.GenreList = genresService.GetAll()
                .Select(g => new SelectListItem { Text = g.Name, Value = g.GenreID.ToString(), Selected = g.GenreID == model.GenreID }).ToList();

            return View(model);
        }
        [HttpPost]
        public IActionResult Update(Book model)
        {
            model.AutherList = authorService.GetAll()
                .Select(a => new SelectListItem
                {
                    Text = a.AuthorName,
                    Value = a.AuthorId.ToString(),
                    Selected = a.AuthorId == model.AuthorId
                }).ToList();
            model.PublisherList = publisherService.GetPublishers()
                .Select(p => new SelectListItem
                {
                    Text = p.PublisherName,
                    Value = p.PublisherId.ToString(),
                    Selected = p.PublisherId == model.PublisherID
                }).ToList();
            model.GenreList = genresService.GetAll()
                .Select(g => new SelectListItem { Text = g.Name, Value = g.GenreID.ToString(), Selected = g.GenreID == model.GenreID }).ToList();
            var result = bookService.Update(model);
            if (result == true)
            {
                TempData["msg"] = "Book Updated Successfully";
                return RedirectToAction(nameof(Index));

            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = bookService.Delete(id);
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

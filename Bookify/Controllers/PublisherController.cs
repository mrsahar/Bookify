using Bookify.Models.Entity;
using Bookify.Repos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisher service;

        public PublisherController(IPublisher service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            var records = service.GetPublishers();
            return View(records);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Publisher publisher)
        {
            var records = service.Add(publisher);
            TempData["msg"] = records == true ? "publisher Added Successfully" : "Not Successful";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var records = service.GetPublisherById(id);
            return View(records);
        }
        [HttpPost]
        public IActionResult Update(Publisher publisher)
        {
            try
            {
                var updateRecord = service.Update(publisher);
                TempData["msg"] = updateRecord == true ? "publisher Update Successfully" : "Not Successful";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(publisher);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var updateRecord = service.Delete(id);
                TempData["msg"] = updateRecord == true ? "Publisher Deleted Successfully" : "Not Successful";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}

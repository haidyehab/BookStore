using BookStore.Models.Domain;
using BookStore.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisher;

        public PublisherController(IPublisherService publisher)
        {
            _publisher = publisher;
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Publisher model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = _publisher.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }

        public IActionResult Update(int id)
        {
            var record = _publisher.FindById(id);
            return View(record);
        }
        [HttpPost]
        public IActionResult Update(Publisher model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = _publisher.Update(model);
            if (result)
            {
                TempData["msg"] = "Updated Successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var result = _publisher.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            var data = _publisher.GetAll();
            return View(data);
        }

    }
}

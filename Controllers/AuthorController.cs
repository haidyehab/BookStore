using BookStore.Models.Domain;
using BookStore.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _author;

        public AuthorController(IAuthorService author)
        {
            _author = author;
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Author model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = _author.Add(model);
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
            var record = _author.FindById(id);
            return View(record);
        }
        [HttpPost]
        public IActionResult Update(Author model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = _author.Update(model);
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
            var result = _author.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            var data = _author.GetAll();
            return View(data);
        }
    }
}

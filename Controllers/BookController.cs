using BookStore.Models.Domain;
using BookStore.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _book;
        private readonly IAuthorService _author;
        private readonly IGenreService _genre;
        private readonly IPublisherService _publisher;

        public BookController(IBookService book,
            IAuthorService author,
            IGenreService genre,
            IPublisherService publisher)
        {
            _book = book;
            _author = author;
            _genre = genre;
            _publisher = publisher;
        }


        public IActionResult Add()
        {
            var model = new Book();
            model.AuthorList = _author.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(),Selected = a.Id==model.AuthorId }).ToList();
            model.PublisherList = _publisher.GetAll().Select(p => new SelectListItem { Text =p.PublisherName , Value = p.Id.ToString(), Selected = p.Id == model.PublisherId }).ToList();
            model.GenreList = _genre.GetAll().Select(g => new SelectListItem { Text = g.Name, Value = g.Id.ToString(), Selected = g.Id == model.GenreId }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Book model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = _book.Add(model);
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
            var model = _book.FindById(id);
            model.AuthorList = _author.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = _publisher.GetAll().Select(p => new SelectListItem { Text = p.PublisherName, Value = p.Id.ToString(), Selected = p.Id == model.PublisherId }).ToList();
            model.GenreList = _genre.GetAll().Select(g => new SelectListItem { Text = g.Name, Value = g.Id.ToString(), Selected = g.Id == model.GenreId }).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(Book model)
        {
            model.AuthorList = _author.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = _publisher.GetAll().Select(p => new SelectListItem { Text = p.PublisherName, Value = p.Id.ToString(), Selected = p.Id == model.PublisherId }).ToList();
            model.GenreList = _genre.GetAll().Select(g => new SelectListItem { Text = g.Name, Value = g.Id.ToString(), Selected = g.Id == model.GenreId }).ToList();
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = _book.Update(model);
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
            var result = _book.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll(int id)
        {
            var data = _book.GetAll();
            return View(data);
        }
    }
}

using BookStore.Models.Domain;
using BookStore.Repository.Abstract;
using BookStore.Repository.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
	public class GenreController : Controller
	{
		private readonly IGenreService _service;

		public GenreController(IGenreService service)
        {
			_service = service;
		}
        public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Add(Genre model)
		{
			if(!ModelState.IsValid)
			{
				return View();
			}
			var result = _service.Add(model);
			if(result)
			{
				TempData["msg"] = "Added Successfully";
				return RedirectToAction(nameof(Add));	
			}
			TempData["msg"] = "Error has occured on server side";
			return View(model);
		}

		public IActionResult Update(int id)
		{
			var record = _service.FindById(id);
			return View(record);
		}
		[HttpPost]
		public IActionResult Update(Genre model)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			var result = _service.Update(model);
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
			var result = _service.Delete(id);
			return RedirectToAction("GetAll");	
		}

		public IActionResult GetAll()
		{
			var data = _service.GetAll();
		   return View(data);
		}


	}
}

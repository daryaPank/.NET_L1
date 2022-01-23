using Business.Services;
using BusinessInterop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class ExampleController: Controller
    {
        private readonly IExampleService _exampleService;
        private readonly IBookService _bookService;

        public ExampleController(IExampleService exampleService, IBookService bookService)
        {
            _exampleService = exampleService;
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            return View(_exampleService.GetExamples());
        }

        public ActionResult Create()
        {
            ViewData["BookIds"] = new SelectList(_bookService.GetBooks(), "Id", "Name");
            return View("CreateOrUpdate");
        }

        public ActionResult Update(int id)
        {
            return View("CreateOrUpdate", _exampleService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(ExampleDto dto)
        {
            var ex = _exampleService.GetByNumber(dto.Number);

            if (!(ex is null) && ex.Number == dto.Number)
            {
                ModelState.AddModelError("Number", "Экземпляр с таким номер уже существует");
            }
            if (!ModelState.IsValid)
            {
                ViewData["BookIds"] = new SelectList(_bookService.GetBooks(), "Id", "Name");
                return View(dto);
            }

            _exampleService.CreateExample(dto);

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _exampleService.DeleteExampleById(id);

            return RedirectToAction("Index");
        }
    }
}

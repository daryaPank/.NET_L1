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
    public class BookController:Controller
    {
        private readonly IBookService _bookService;
        private readonly IGenreService _genreService;

        public BookController(IBookService bookService, IGenreService genreService)
        {
            _bookService = bookService;
            _genreService = genreService;
        }

        public IActionResult Index()
        {
            return View(_bookService.GetBooks());
        }

        public ActionResult Create()
        {
            ViewData["GenreIds"] = new SelectList(_genreService.GetGenres(), "Id", "Name");
            return View("CreateOrUpdate");
        }

        public ActionResult Update(int id)
        {
            return View("CreateOrUpdate", _bookService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(BookDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _bookService.CreateBook(dto);

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _bookService.DeleteBookById(id);

            return RedirectToAction("Index");
        }
    }
}

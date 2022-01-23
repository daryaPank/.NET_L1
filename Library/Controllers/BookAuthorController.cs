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
    public class BookAuthorController: Controller
    {
        private readonly IBookAuthorService _bookAuthorService;
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public BookAuthorController(IBookAuthorService bookAuthorService, IBookService bookService, IAuthorService authorService)
        {
            _bookAuthorService = bookAuthorService;
            _bookService = bookService;
            _authorService = authorService;
        }

        public IActionResult Index()
        {
            return View(_bookAuthorService.GetAll());
        }

        public ActionResult Create()
        {
            ViewData["AuthorIds"] = new SelectList(_authorService.GetAuthors(), "Id", "Name");
            ViewData["BookIds"] = new SelectList(_bookService.GetBooks(), "Id", "Name");

            return View("CreateOrUpdate");
        }

        public ActionResult Update(int id)
        {
            return View("CreateOrUpdate", _bookAuthorService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(BookAuthorDto dto)
        {
            var books = _bookAuthorService.GetByBook(dto);
            var cnt = books.Count(b => b.BookId == dto.BookId && b.AuthorId == dto.AuthorId)==0?0: books.Count(b => b.BookId == dto.BookId && b.AuthorId == dto.AuthorId);

            if (!(books is null) && cnt != 0)
            {
                ModelState.AddModelError("BookId", "Информация о данном авторстве уже добавлена");
                ModelState.AddModelError("AuthorID", "Информация о данном авторстве уже добавлена");
            }
            if (!ModelState.IsValid)
            {
                ViewData["AuthorIds"] = new SelectList(_authorService.GetAuthors(), "Id", "Name");
                ViewData["BookIds"] = new SelectList(_bookService.GetBooks(), "Id", "Name");
                return View(dto);
            }

            _bookAuthorService.CreateBookAuthor(dto);

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _bookAuthorService.DeleteById(id);

            return RedirectToAction("Index");
        }
    }
}

using Business.Services;
using BusinessInterop.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class AuthorController:Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public IActionResult Index()
        {
            return View(_authorService.GetAuthors());
        }

        public ActionResult Create()
        {
            return View("CreateOrUpdate");
        }

        public ActionResult Update(int id)
        {
            return View("CreateOrUpdate", _authorService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(AuthorDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _authorService.CreateAuthor(dto);

            return RedirectToAction("Index");
        }
        
    }
}

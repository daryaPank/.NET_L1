using Business.Services;
using BusinessInterop.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class LibrarianController: Controller
    {
        private readonly ILibrarianService _librarianService;

        public LibrarianController(ILibrarianService librarianService)
        {
            _librarianService = librarianService;
        }

        public IActionResult Index()
        {
            return View(_librarianService.GetLibrarians());
        }

        public ActionResult Create()
        {
            return View("CreateOrUpdate");
        }

        public ActionResult Update(int id)
        {
            return View("CreateOrUpdate", _librarianService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(LibrarianDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _librarianService.CreateLibrarian(dto);

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _librarianService.DeleteById(id);

            return RedirectToAction("Index");
        }
    }
}

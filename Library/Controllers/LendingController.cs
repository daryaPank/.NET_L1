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
    public class LendingController: Controller
    {
        private readonly ILendingService _lendingService;
        private readonly ILibrarianService _librarianService;
        private readonly IReaderService _readerService;
        private readonly IExampleService _exampleService;

        public LendingController(ILendingService lendingService, ILibrarianService librarianService, IReaderService readerService, IExampleService exampleService)
        {
            _lendingService = lendingService;
            _librarianService = librarianService;
            _readerService = readerService;
            _exampleService = exampleService;
        }

        public IActionResult Index()
        {
            return View(_lendingService.GetLendings());
        }

        public ActionResult Create()
        {
            ViewData["ExampleIds"] = new SelectList(_exampleService.GetExamples().Select(e => new { e.Id, numberBook=e.Number+" "+e.Book.Name}), "Id", "numberBook");
            ViewData["LibrarianIds"] = new SelectList(_librarianService.GetLibrarians(), "Id", "Name");
            ViewData["ReaderIds"] = new SelectList(_readerService.GetReaders(), "Id", "Name");
            return View("CreateOrUpdate");
        }

        public ActionResult Update(int id)
        {
            return View("CreateOrUpdate", _lendingService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(LendingDto dto)
        {
            var lends = _lendingService.FindByReaderId(dto.ReaderId);
            var cnt = lends.Count(l => l.ReaderId == dto.ReaderId && l.Start == dto.Start && l.ExampleId == dto.ExampleId)==0?0: lends.Count(l => l.ReaderId == dto.ReaderId && l.Start == dto.Start && l.ExampleId == dto.ExampleId);

            if (cnt != 0)
            {
                ModelState.AddModelError("ExampleId", "Такая выдача уже существует");
            }
            if (!ModelState.IsValid)
            {
                ViewData["ExampleIds"] = new SelectList(_exampleService.GetExamples().Select(e => new { e.Id, numberBook = e.Number + " " + e.Book.Name }), "Id", "numberBook");
                ViewData["LibrarianIds"] = new SelectList(_librarianService.GetLibrarians(), "Id", "Name");
                ViewData["ReaderIds"] = new SelectList(_readerService.GetReaders(), "Id", "Name");

                return View(dto);
            }

            _lendingService.CreateLending(dto);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _lendingService.DeleteById(id);

            return RedirectToAction("Index");
        }
    }
}

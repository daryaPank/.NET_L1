using Business.Services;
using BusinessInterop.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class ReaderController: Controller
    {
        private readonly IReaderService _readerService;

        public ReaderController(IReaderService readerService)
        {
            _readerService = readerService;
        }

        public IActionResult Index()
        {
            return View(_readerService.GetReaders());
        }

        public ActionResult Create()
        {
            return View("CreateOrUpdate");
        }

        public ActionResult Update(int id)
        {
            return View("CreateOrUpdate", _readerService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(ReaderDto dto)
        {
            var readers = _readerService.GetByName(dto.Name);
            var cnt = readers.Count(r => r.Name == dto.Name && r.Address == dto.Address) == 0 ? 0 : readers.Count(r => r.Name == dto.Name && r.Address == dto.Address);
            if (cnt != 0)
            {
                ModelState.AddModelError("Name", "Такой читатель уже существует");
                ModelState.AddModelError("Address", "Такой читатель уже существует");
            }
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _readerService.CreateReader(dto);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _readerService.DeleteReaderById(id);

            return RedirectToAction("Index");
        }
    }
}

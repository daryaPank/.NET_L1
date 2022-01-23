using Business.Services;
using BusinessInterop.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class GenreController: Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public IActionResult Index()
        {
            return View(_genreService.GetGenres());
        }

        public ActionResult Create()
        {
            return View("CreateOrUpdate");
        }

        public ActionResult Update(int id)
        {
            return View("CreateOrUpdate", _genreService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(GenreDto dto)
        {
            var genres = _genreService.GetGenres();
            var cnt = genres.Count(g => g.Name == dto.Name)==0?0: genres.Count(g => g.Name == dto.Name);

            if (cnt != 0)
            {
                ModelState.AddModelError("Name", "Такой жанр уже существует");
            }
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _genreService.CreateGenre(dto);

            return RedirectToAction("Index");
        }
    }
}

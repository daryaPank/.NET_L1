using BusinessInterop.Data;
using System.Collections.Generic;

namespace Business.Services
{
    public interface IGenreService
    {
        public GenreDto CreateGenre(GenreDto genre);
        public IEnumerable<GenreDto> GetGenres();
        public GenreDto GetById(int id);
    }
}

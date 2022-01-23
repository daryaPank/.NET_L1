using BusinessInterop.Data;
using System.Collections.Generic;

namespace Business.Services
{
    public interface IBookService
    {
        public BookDto CreateBook(BookDto book);
        public void DeleteBookById(int id);
        public IEnumerable<BookDto> GetBooks();
        public BookDto GetById(int id);

        public IEnumerable<BookDto> GetByYear(int year);
        public BookDto GetByName(string name);
        public IEnumerable<BookDto> FindByGenre(GenreDto genre);
    }
}

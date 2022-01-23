using BusinessInterop.Data;
using System.Collections.Generic;

namespace Business.Services
{
    public interface IBookAuthorService
    {
        public BookAuthorDto CreateBookAuthor(BookAuthorDto bookAuthor);

        public IEnumerable<BookAuthorDto> GetAll();
        public BookAuthorDto GetById(int id);
        public IEnumerable<BookAuthorDto> GetByBook(BookAuthorDto bookAuthor);
        public void DeleteById(int id);
    }
}

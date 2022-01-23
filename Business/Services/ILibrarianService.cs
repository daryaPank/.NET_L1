using BusinessInterop.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public interface ILibrarianService
    {
        public LibrarianDto CreateLibrarian(LibrarianDto librarian);
        public IEnumerable<LibrarianDto> GetLibrarians();
        public LibrarianDto GetById(int id);
        public LibrarianDto GetByName(string name);
        public void DeleteById(int id);
    }
}

using Business.Entities;
using Business.Repositories.DataRepositories;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class BookRepository : AbstractRepository<Book, int>, IBookRepository
    {
        public BookRepository(Context context)
        {
            _context = context;
        }

        #region implementation
        protected override int KeySelector(Book entity) => entity.Id;

        protected override Book ReadImplementation(int key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Book> ReadImplementationAsync(int key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void CreateImplementation(Book value)
        {
            _context.Books.Add(value);
        }

        protected override async Task CreateImplementationAsync(Book value)
        {
            await _context.Books.AddAsync(value);
        }
        protected override void UpdateImplementation( Book value)
        {
            _context.Update(value);
        }

        protected override void DeleteImplementation(Book value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null) return;
            _context.Books.Remove(entity);
        }

        protected override IQueryable<Book> QueryImplementation()
        {
            return _context.Books.Include(b => b.Genre);
        }
        #endregion
    }
}

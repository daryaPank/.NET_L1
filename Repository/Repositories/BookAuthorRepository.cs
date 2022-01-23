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
    public class BookAuthorRepository : AbstractRepository<BookAuthor, int>, IBookAuthorRepository
    {
        public BookAuthorRepository(Context context)
        {
            _context = context;
        }


        protected override int KeySelector(BookAuthor entity) => entity.Id;

        protected override BookAuthor ReadImplementation(int key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<BookAuthor> ReadImplementationAsync(int key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void CreateImplementation(BookAuthor value)
        {
            _context.BookAuthors.Add(value);
        }

        protected override async Task CreateImplementationAsync(BookAuthor value)
        {
            await _context.BookAuthors.AddAsync(value);
        }
        protected override void UpdateImplementation(BookAuthor value)
        {
            _context.Update(value);
        }

        protected override void DeleteImplementation(BookAuthor value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity != null) return;
            _context.BookAuthors.Remove(entity);
        }

        protected override IQueryable<BookAuthor> QueryImplementation()
        {
            return _context.BookAuthors.Include(b => b.Author).Include(b => b.Book);
        }
    }
}

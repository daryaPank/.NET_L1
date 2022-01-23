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
    public class AuthorRepository: AbstractRepository<Author, int>, IAuthorRepository
    {
        public AuthorRepository(Context context)
        {
            _context = context;
        }

        #region implementation
        protected override int KeySelector(Author entity) => entity.Id;

        protected override Author ReadImplementation(int key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Author> ReadImplementationAsync(int key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void CreateImplementation(Author value)
        {
            _context.Authors.Add(value);
        }

        protected override async Task CreateImplementationAsync(Author value)
        {
            await _context.Authors.AddAsync(value);
        }
        protected override void UpdateImplementation( Author value)
        {
            _context.Update(value);
        }

        protected override void DeleteImplementation(Author value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null) return;
            _context.Authors.Remove(entity);
        }

        protected override IQueryable<Author> QueryImplementation()
        {
            return _context.Authors;
        }
        #endregion
    }
}

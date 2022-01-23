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
    public class ReaderRepository : AbstractRepository<Reader, int>, IReaderRepository
    {
        public ReaderRepository(Context context)
        {
            _context = context;
        }

        #region implementation
        protected override int KeySelector(Reader entity) => entity.Id;

        protected override Reader ReadImplementation(int key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Reader> ReadImplementationAsync(int key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void CreateImplementation(Reader value)
        {
            _context.Readers.Add(value);
        }

        protected override async Task CreateImplementationAsync(Reader value)
        {
            await _context.Readers.AddAsync(value);
        }
        protected override void UpdateImplementation(Reader value)
        {
            _context.Update(value);
        }

        protected override void DeleteImplementation(Reader value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null) return;
            _context.Readers.Remove(entity);
        }

        protected override IQueryable<Reader> QueryImplementation()
        {
            return _context.Readers;
        }
        #endregion
    }
}

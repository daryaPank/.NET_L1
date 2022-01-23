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
    public class LendingRepository : AbstractRepository<Lending, int>, ILendingRepository
    {
        public LendingRepository(Context context)
        {
            _context = context;
        }

        #region implementation
        protected override int KeySelector(Lending entity) => entity.Id;

        protected override Lending ReadImplementation(int key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Lending> ReadImplementationAsync(int key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void CreateImplementation(Lending value)
        {
            _context.Lendings.Add(value);
        }

        protected override async Task CreateImplementationAsync(Lending value)
        {
            await _context.Lendings.AddAsync(value);
        }
        protected override void UpdateImplementation( Lending value)
        {
            _context.Update(value);
        }

        protected override void DeleteImplementation(Lending value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null) return;
            _context.Lendings.Remove(entity);
        }

        protected override IQueryable<Lending> QueryImplementation()
        {
            return _context.Lendings.Include(b => b.Reader).Include(b => b.Librarian).Include(b => b.Example);
        }
        #endregion
    }
}

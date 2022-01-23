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
    public class ExampleRepository : AbstractRepository<Example, int>, IExampleRepository
    {
        public ExampleRepository(Context context)
        {
            _context = context;
        }
        protected override void CreateImplementation(Example value)
        {
            _context.Examples.Add(value);
        }

        protected override async Task CreateImplementationAsync(Example value)
        {
            await _context.Examples.AddAsync(value);
        }

        protected override void DeleteImplementation(Example value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null) return;
            _context.Examples.Remove(entity);
        }

        protected override int KeySelector(Example entity) => entity.Id;

        protected override IQueryable<Example> QueryImplementation()
        {
            return _context.Examples.Include(b => b.Book);
        }

        protected override Example ReadImplementation(int key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Example> ReadImplementationAsync(int key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(Example value)
        {
            _context.Update(value);
        }
    }
}

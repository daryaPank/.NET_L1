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
    public class LibrarianRepository:AbstractRepository<Librarian, int>, ILibrarianRepository
    {
        public LibrarianRepository(Context context)
    {
        _context = context;
    }

    #region implementation
    protected override int KeySelector(Librarian entity) => entity.Id;

    protected override Librarian ReadImplementation(int key)
    {
        return QueryImplementation().FirstOrDefault(i => i.Id == key);
    }

    protected override async Task<Librarian> ReadImplementationAsync(int key)
    {
        return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
    }

    protected override void CreateImplementation(Librarian value)
    {
        _context.Librarians.Add(value);
    }

    protected override async Task CreateImplementationAsync(Librarian value)
    {
        await _context.Librarians.AddAsync(value);
    }
    protected override void UpdateImplementation(Librarian value)
    {
        _context.Update(value);
    }

    protected override void DeleteImplementation(Librarian value)
    {
        var entity = ReadImplementation(value.Id);
        if (entity == null) return;
        _context.Librarians.Remove(entity);
    }

    protected override IQueryable<Librarian> QueryImplementation()
    {
        return _context.Librarians;
    }
    #endregion
}
}

using Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class Context: DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Example> Examples { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Lending> Lendings { get; set; }
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public Context(DbContextOptions<Context> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        
    }
}

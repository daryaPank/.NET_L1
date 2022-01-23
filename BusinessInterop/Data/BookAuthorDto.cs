using BusinessInterop.Data;

namespace BusinessInterop.Data
{
    public class BookAuthorDto
    {
        public int Id { get; set; }
        public BookDto Book { get; set; }
        public int BookId { get; set; }
        public AuthorDto Author { get; set; }
        public int AuthorId { get; set; }

    }
}

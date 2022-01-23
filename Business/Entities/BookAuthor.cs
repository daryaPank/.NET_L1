using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    // промежуточная таблица многие ко многим для авторов у книги
    // у книги мб много авторов и один автор мб у разных книг
    public class BookAuthor
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public Author Author { get; set; }
        public int  AuthorId { get; set; }


    }
}

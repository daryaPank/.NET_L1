using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

       
        // id жанра
        public Genre Genre { get; set; }
        public int GenreId { get; set; }

        

        public IEnumerable<Example> Examples { get; set; }
        public IEnumerable<BookAuthor> BookAuthors { get; set; }

    }
}

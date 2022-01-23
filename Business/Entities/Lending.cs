using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{

    public class Lending
    {
        public int Id { get; set; }
        // id читателя
        public Reader Reader {get;set;}
        public int ReaderId { get; set; }

        public Librarian Librarian { get; set; }
        public int LibrarianId { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
        // id книги 
        public Example Example { get; set; }
        public int ExampleId { get; set; }
    }
}

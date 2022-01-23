using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class Example
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
       
        public IEnumerable<Lending> Lendings { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class Librarian
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Lending> Lendings { get; set; }
    }
}

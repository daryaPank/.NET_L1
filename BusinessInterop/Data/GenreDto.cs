using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessInterop.Data
{
    public class GenreDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите название")]
        public string Name { get; set; }

        public IEnumerable<BookDto> Books { get; set; }
    }
}

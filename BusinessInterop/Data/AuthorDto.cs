using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessInterop.Data
{
    public class AuthorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Укажите ФИО автора")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите страну автора")]
        public string Country { get; set; }

        public IEnumerable<BookAuthorDto> BookAuthors { get; set; }
    }
}

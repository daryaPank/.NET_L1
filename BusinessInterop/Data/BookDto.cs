using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessInterop.Data
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите название книги")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите год создания книги")]
        [Range(1800,2022, ErrorMessage ="Год создания должен быть в диапазоне от 1800 до 2022")]
        public int Year { get; set; }
                
        // id жанра
        public GenreDto Genre { get; set; }
        [Required(ErrorMessage ="Необходимо указать жанр")]
        public int GenreId { get; set; }

        public IEnumerable<BookAuthorDto> BookAuthors { get; set; }
        public IEnumerable<ExampleDto> Examples { get; set; }
    }
}

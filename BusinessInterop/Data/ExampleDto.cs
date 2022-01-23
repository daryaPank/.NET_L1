using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessInterop.Data
{
    public class ExampleDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите инвентарный номер экземпляра")]
        public int Number { get; set; }

        public BookDto Book { get; set; }

        [Required(ErrorMessage = "Укажите название книги")]
        public int BookId { get; set; }

        public IEnumerable<LendingDto> Lendings { get; set; }
    }
}

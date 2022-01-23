using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessInterop.Data
{
    public class LibrarianDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите ФИО")]
        public string Name { get; set; }

        public IEnumerable<LendingDto> Lendings { get; set; }
    }
}

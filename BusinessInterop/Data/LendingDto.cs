
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessInterop.Data
{
    public class LendingDto
    {
        public int Id { get; set; }


        // id читателя
        public ReaderDto Reader { get; set; }
        [Required(ErrorMessage = "Необходимо указать читателя")]
        public int ReaderId { get; set; }

        public LibrarianDto Librarian { get; set; }
        [Required(ErrorMessage = "Необходимо указать читателя")]
        public int LibrarianId { get; set; }
        // id экземпляра  
        public ExampleDto Example { get; set; }
        public int ExampleId { get; set; }

        [Required(ErrorMessage = "Необходимо указать дату выдачи книги")]
        public DateTime Start { get; set; }

        [Required(ErrorMessage = "Необходимо указать дату сдачи книги")]
        //[GreaterThan("Start", ErrorMessage="Дата сдачи книги должна быть больше даты выдачи")]
        public DateTime End { get; set; }
    }
}

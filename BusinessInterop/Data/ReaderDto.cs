using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessInterop.Data
{
    public class ReaderDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Необходимо указать ФИО")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Необходимо указать телефон")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Необходимо указать адрес")]
        public string Address { get; set; }
    }
}

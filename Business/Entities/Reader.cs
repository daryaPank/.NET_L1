﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public IEnumerable<Lending> Lendings { get; set; }
    }
}

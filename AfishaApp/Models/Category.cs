﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfishaApp.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        public List<Afisha> Afishas { get; set; } = new List<Afisha>();
    }
}

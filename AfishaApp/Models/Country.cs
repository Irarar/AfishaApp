using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfishaApp.Models
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AfishaApp.Models
{
    public class Afisha
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int CountTicket { get; set; }
        public Guid? CategoryId { get; set; }
        public  Category Category { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AfishaApp.Models;

namespace AfishaApp.ViewModel
{
    public class HomeVM
    {
        public IEnumerable<Afisha> Afishas { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}

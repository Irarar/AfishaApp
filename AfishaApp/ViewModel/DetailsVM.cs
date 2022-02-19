using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AfishaApp.Models;

namespace AfishaApp.ViewModel
{
    public class DetailsVM
    {
        public DetailsVM()
        {
            Afisha = new Afisha();
        }

        public Afisha Afisha { get; set; }
        public bool ExistsInCart { get; set; }
    }
}

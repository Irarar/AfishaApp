using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfishaApp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; } 
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

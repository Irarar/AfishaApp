using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AfishaApp.Models
{
    public class ApplicationUser: IdentityUser
    {
        [DisplayName("Full Name")]
        public string FullName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Battleship.Model.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Game> Games { get; set; }

        public static explicit operator ApplicationUser(Task<ApplicationUser> v)
        {
            throw new NotImplementedException();
        }
    }
}


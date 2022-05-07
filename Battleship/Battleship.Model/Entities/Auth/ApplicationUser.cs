using System;
using System.Security;
using Microsoft.AspNetCore.Identity;

namespace Battleship.Model.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}


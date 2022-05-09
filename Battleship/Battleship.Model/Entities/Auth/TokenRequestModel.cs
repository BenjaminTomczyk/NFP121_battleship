using System;
using System.ComponentModel.DataAnnotations;

namespace Battleship.Model.Entities
{
    public class TokenRequestModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}


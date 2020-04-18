using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Fimly.Data.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Please use a shorter first name.")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "Please use a shorter last name.")]
        public string LastName { get; set; }

        public DateTime? LastLogin { get; set; }
        public DateTime Registered { get; set; }

        public bool HasLoggedInBefore()
        {
            return LastLogin.HasValue ? true : false;
        }
    }
}

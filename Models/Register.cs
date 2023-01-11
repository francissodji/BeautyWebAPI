using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Username is required")]
        [MinLength(8)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password confirmation is required")]
        public string ConfPassword { get; set; }


        //For Client and Braider
        [MaxLength(30)]
        public string Role { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        public bool Connectstate { get; set; }

        public string SubDomaine { get; set; }

        /*
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Cell Phone number is required")]
        [Phone]
        public string Cel { get; set; }

        [MaxLength(1)]
        public string Sex { get; set; }

        public DateTime DOB { get; set; }
        
        public string Street { get; set; }

        public string County { get; set; }

        public string ZipCode { get; set; }

        [MaxLength(2)]
        public string State { get; set; }
        */
    }
}

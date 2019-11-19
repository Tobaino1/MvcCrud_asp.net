using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcCrud.ViewModel
{
    public class Register
    {
        [Required]
        [Display (Name ="Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Phone Number ")]
        public string PhoneNumber { get; set; }

        [Required]
        //we will use reguslar expression to check if email is valid lie for tobi@test.com
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@(a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class LoginviewModel
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@(a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
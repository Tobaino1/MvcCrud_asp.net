using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MvcCrud.ViewModel
{
    public class LoginViewModel
    {
            [Required]
            [RegularExpression("^[a-zA-Z0-9_\\.-]+@(a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Password")]
            public string Password { get; set; }
        
    }
}
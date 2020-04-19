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
              [Display(Name = "Username")]
             public string Username { get; set; }

              [Required]
              [Display(Name = "Password")]
            public string Password { get; set; }
        
    }
}
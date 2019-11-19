using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security; //add this for basic security feature
using MvcCrud.Models; //add this i.e name of application.models


namespace MvcCrud.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account (home page)
        public ActionResult Index()
        {
            return View();
        }

        // GET: Register view
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveRegistrationDetails(RegisterUser registerUser) // (dbname  parameter)
        {
            if  (ModelState.IsValid)
            {
                using (RegLoginConstring db = new RegLoginConstring())

               //If the model state is valid i.e the form values passed the validation then we are storing d user's details in DB
                {
                    //save all the details in registeruser object
                    db.RegisterUsers.Add(registerUser);
                    db.SaveChanges();
                }
                ViewBag.Message = "User Details Saved";
                return View("Register");         
            }
            else
            {
                //if the validation fails, we are returning the model object with errors to d view, whc will dislay error msgs.
                return View("Register", registerUser);
            }
        }
    }
}
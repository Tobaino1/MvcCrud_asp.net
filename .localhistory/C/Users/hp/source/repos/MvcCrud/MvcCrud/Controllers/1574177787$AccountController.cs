using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security; //add this for basic security feature
using MvcCrud.Models; //add this i.e name of application.models
using MvcCrud.ViewModel; //add this it will be created as a class later in the viewmodel folder


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
        public ActionResult Register() //add this view
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
                    db.RegisterUser.Add(registerUser);
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



        public ActionResult Login() //add this view
        {
            return View();
        }

        //The login form is posted to this method
        [HttpPost]
        public  ActionResult Login (RegisterUser theuser)
        {
            //checking the state of model passed as parameter.
            if (ModelState.IsValid)
            {
                // validating the user, whether the user is valid or not.
                var isValidUser = IsValidUser(theuser);

                //if useris valid n present in db, we are redirecting it to welcome page
                if (isValidUser != null)
                {
                    FormsAuthentication.SetAuthCookie(theuser.Email, false);
                    return RedirectToAction("index");
                }
                else
                {
                    //ifthe username n password combination is not present indb then error msg is shown
                    ModelState.AddModelError("Faiure", "Wrong Username and Password Combination !");
                    return View();
                }
            }
            else
            {
                //if model state is not valid, the model with error message is returned to the view
                return View(theuser);
            }
            }

        //function to check if user is valid or not
        public RegisterUser IsValidUser(RegisterUser theuser)
        {
            using (var dataContext = new RegLoginConstring())
            {
                //Retrieving the user details from db based on username and password enetered by the user
                RegisterUser user = dataContext.RegisterUsers.Where(query => query.Email.Equals(theuser.Email) && query.Password.Equals(theuser.Password)).SingleOrDefault();

                //if user is present, then true is returned.
                if (user == null)
                    return null;
                //if user is not present false is returned.
                else
                    return user;
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); //it will clear the session at the end of request
            return RedirectToAction("Index");
        }
    }
}
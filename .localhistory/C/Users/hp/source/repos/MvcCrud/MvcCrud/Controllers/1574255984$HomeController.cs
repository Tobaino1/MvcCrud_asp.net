using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCrud.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "PAOYEK INDUSTRY.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your request is our ultimate task.";

            return View();
        }
    }
}
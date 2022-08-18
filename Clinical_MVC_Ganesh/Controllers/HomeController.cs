using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinical_MVC_Ganesh.Controllers
{
    public class HomeController : Controller
    {
        
        

        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult HomePage()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Receptionist()
        {
            ViewBag.Message = "Receptionist Page";

            return View();
        }
        public ActionResult Laboratorian()
        {
            ViewBag.Message = "Laboratory page.";

            return View();
        }
        public ActionResult Doctor()
        {
            ViewBag.Message = "Doctor page.";

            return View();
        }


    }
}
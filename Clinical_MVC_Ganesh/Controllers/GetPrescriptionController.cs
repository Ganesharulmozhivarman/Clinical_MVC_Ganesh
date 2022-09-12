using Clinical_MVC_Ganesh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinical_MVC_Ganesh.Controllers
{
    [Authorize(Roles = "Laboratorian")]
    public class GetPrescriptionController : Controller
    {
        private ClinicMVCDbEntities db = new ClinicMVCDbEntities();
        // GET: GetPrescription
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.PrescriptionTbls.ToList());
        }
        [HttpPost]
        public ActionResult Index(DateTime start,DateTime end)
        {
            return View(db.GetPresciption(start,end));
        }
    }
}
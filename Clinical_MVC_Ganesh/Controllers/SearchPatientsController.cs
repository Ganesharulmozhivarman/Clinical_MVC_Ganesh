using Clinical_MVC_Ganesh.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinical_MVC_Ganesh.Controllers
{
    public class SearchPatientsController : Controller
    {

        private ClinicMVCDbEntities db = new ClinicMVCDbEntities();
        // GET: SearchPatients
        [Authorize(Roles = "Receptionist")]
        public ActionResult Index()
        {
            return View(db.PatientTbls.ToList());
        }
        [HttpPost]
        public ActionResult Index(string PatName)
        {
            return View(db.SearchPatients_Result(PatName));
        }
        public ActionResult PrintAllReport()
        {
            var report = new ActionAsPdf("Index");
            return report;
        }
        public ActionResult IndexById(int id)
        {
            var pat = db.PatientTbls.Where(e => e.PatId == id).First();
            return View(pat);
        }
        public ActionResult PrintPatientsSummary(int id)
        {
            var report = new ActionAsPdf("IndexById", new { id = id });
            return report;
        }



    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using Clinical_MVC_Ganesh.Models;


namespace Clinical_MVC_Ganesh.Controllers
{
    public class PrescriptionTblsController : Controller
    {
        private ClinicMVCDbEntities db = new ClinicMVCDbEntities();

        // GET: PrescriptionTbls
        public ActionResult Index()
        {
            var prescriptionTbls = db.PrescriptionTbls.Include(p => p.DoctorTbl).Include(p => p.LabTestTbl).Include(p => p.PatientTbl);
            return View(prescriptionTbls.ToList());
        }


        // GET: PrescriptionTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrescriptionTbl prescriptionTbl = db.PrescriptionTbls.Find(id);
            if (prescriptionTbl == null)
            {
                return HttpNotFound();
            }
            return View(prescriptionTbl);
        }

        // GET: PrescriptionTbls/Create
        public ActionResult Create()
        {
            ViewBag.Doctor = new SelectList(db.DoctorTbls, "DocId", "DocName");
            ViewBag.LabTest = new SelectList(db.LabTestTbls, "TestId", "TestName");
            ViewBag.Patient = new SelectList(db.PatientTbls, "PatId", "PatName");
            return View();
        }

        // POST: PrescriptionTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrescId,Doctor,Patient,Medicines,LabTest,Cost,Date")] PrescriptionTbl prescriptionTbl)
        {
            if (ModelState.IsValid)
            {
                db.PrescriptionTbls.Add(prescriptionTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Doctor = new SelectList(db.DoctorTbls, "DocId", "DocName", prescriptionTbl.Doctor);
            ViewBag.LabTest = new SelectList(db.LabTestTbls, "TestId", "TestName", prescriptionTbl.LabTest);
            ViewBag.Patient = new SelectList(db.PatientTbls, "PatId", "PatName", prescriptionTbl.Patient);
            return View(prescriptionTbl);
        }

        // GET: PrescriptionTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrescriptionTbl prescriptionTbl = db.PrescriptionTbls.Find(id);
            if (prescriptionTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.Doctor = new SelectList(db.DoctorTbls, "DocId", "DocName", prescriptionTbl.Doctor);
            ViewBag.LabTest = new SelectList(db.LabTestTbls, "TestId", "TestName", prescriptionTbl.LabTest);
            ViewBag.Patient = new SelectList(db.PatientTbls, "PatId", "PatName", prescriptionTbl.Patient);
            return View(prescriptionTbl);
        }

        // POST: PrescriptionTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrescId,Doctor,Patient,Medicines,LabTest,Cost,Date")] PrescriptionTbl prescriptionTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prescriptionTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Doctor = new SelectList(db.DoctorTbls, "DocId", "DocName", prescriptionTbl.Doctor);
            ViewBag.LabTest = new SelectList(db.LabTestTbls, "TestId", "TestName", prescriptionTbl.LabTest);
            ViewBag.Patient = new SelectList(db.PatientTbls, "PatId", "PatName", prescriptionTbl.Patient);
            return View(prescriptionTbl);
        }

        // GET: PrescriptionTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrescriptionTbl prescriptionTbl = db.PrescriptionTbls.Find(id);
            if (prescriptionTbl == null)
            {
                return HttpNotFound();
            }
            return View(prescriptionTbl);
        }

        // POST: PrescriptionTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrescriptionTbl prescriptionTbl = db.PrescriptionTbls.Find(id);
            db.PrescriptionTbls.Remove(prescriptionTbl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

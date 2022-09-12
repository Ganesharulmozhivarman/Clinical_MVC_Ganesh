using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Clinical_MVC_Ganesh.Models;

namespace Clinical_MVC_Ganesh.Controllers
{
    [Authorize(Roles = "Laboratorian")]
    public class ReportTblsController : Controller
    {
        private ClinicMVCDbEntities db = new ClinicMVCDbEntities();

        // GET: ReportTbls
        public ActionResult Index()
        {
            var reportTbls = db.ReportTbls.Include(r => r.LaboratorianTbl).Include(r => r.LabTestTbl).Include(r => r.PatientTbl);
            return View(reportTbls.ToList());
        }

        // GET: ReportTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportTbl reportTbl = db.ReportTbls.Find(id);
            if (reportTbl == null)
            {
                return HttpNotFound();
            }
            return View(reportTbl);
        }

        // GET: ReportTbls/Create
        public ActionResult Create()
        {
            ViewBag.Laboratorian = new SelectList(db.LaboratorianTbls, "LabId", "LabName");
            ViewBag.TestName = new SelectList(db.LabTestTbls, "TestId", "TestName");
            ViewBag.Patient = new SelectList(db.PatientTbls, "PatId", "PatName");
            return View();
        }

        // POST: ReportTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReportId,TestDate,TestSummary,Laboratorian,Patient,TestName")] ReportTbl reportTbl)
        {
            if (ModelState.IsValid)
            {
                db.ReportTbls.Add(reportTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Laboratorian = new SelectList(db.LaboratorianTbls, "LabId", "LabName", reportTbl.Laboratorian);
            ViewBag.TestName = new SelectList(db.LabTestTbls, "TestId", "TestName", reportTbl.TestName);
            ViewBag.Patient = new SelectList(db.PatientTbls, "PatId", "PatName", reportTbl.Patient);
            return View(reportTbl);
        }

        // GET: ReportTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportTbl reportTbl = db.ReportTbls.Find(id);
            if (reportTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.Laboratorian = new SelectList(db.LaboratorianTbls, "LabId", "LabName", reportTbl.Laboratorian);
            ViewBag.TestName = new SelectList(db.LabTestTbls, "TestId", "TestName", reportTbl.TestName);
            ViewBag.Patient = new SelectList(db.PatientTbls, "PatId", "PatName", reportTbl.Patient);
            return View(reportTbl);
        }

        // POST: ReportTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReportId,TestDate,TestSummary,Laboratorian,Patient,TestName")] ReportTbl reportTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Laboratorian = new SelectList(db.LaboratorianTbls, "LabId", "LabName", reportTbl.Laboratorian);
            ViewBag.TestName = new SelectList(db.LabTestTbls, "TestId", "TestName", reportTbl.TestName);
            ViewBag.Patient = new SelectList(db.PatientTbls, "PatId", "PatName", reportTbl.Patient);
            return View(reportTbl);
        }

        // GET: ReportTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportTbl reportTbl = db.ReportTbls.Find(id);
            if (reportTbl == null)
            {
                return HttpNotFound();
            }
            return View(reportTbl);
        }

        // POST: ReportTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReportTbl reportTbl = db.ReportTbls.Find(id);
            db.ReportTbls.Remove(reportTbl);
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
